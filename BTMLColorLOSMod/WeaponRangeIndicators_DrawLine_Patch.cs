using System.Collections.Generic;
using BattleTech;
using BattleTech.UI;
using Harmony;
using UnityEngine;

namespace BTMLColorLOSMod
{
    [HarmonyPatch(typeof(BattleTech.UI.WeaponRangeIndicators), "DrawLine")]
    public static class WeaponRangeIndicators_DrawLine_Patch
    {
        static bool Prefix(
            ref Vector3 position,
            ref Quaternion rotation,
            ref bool isPositionLocked,
            ref AbstractActor selectedActor,
            ref ICombatant target,
            ref bool usingMultifire,
            ref bool isLocked,
            ref bool isMelee,
            WeaponRangeIndicators __instance)
        {
            // var colorSettings = SettingsHelper.LoadSettings();
            CombatHUD HUD = (CombatHUD) ReflectionHelper.GetPrivateProperty(__instance, "HUD");
            // set up this line drawer because it has some materials we want later

            if (__instance.DEBUG_showLOSLines)
            {
                DEBUG_LOSLineDrawer debugDrawer =
                    (DEBUG_LOSLineDrawer) ReflectionHelper.InvokePrivateMethode(__instance, "GetDebugDrawer",
                        new object[] { });
                debugDrawer.DrawLines(selectedActor, HUD.SelectionHandler.ActiveState, target);
            }

            LineRenderer line =
                (LineRenderer) ReflectionHelper.InvokePrivateMethode(__instance, "getLine", new object[] { });
            Vector3 vector = Vector3.Lerp(position, position + selectedActor.HighestLOSPosition,
                __instance.sourceLaserDestRatio);
            Vector3 vector2 = Vector3.Lerp(target.CurrentPosition, target.TargetPosition,
                __instance.targetLaserDestRatio);
            AbstractActor targetActor = target as AbstractActor;
            // melee
            if (isMelee)
            {
                line.startWidth = __instance.LOSWidthBegin;
                line.endWidth = __instance.LOSWidthEnd;
                line.material = __instance.MaterialInRange;
                line.startColor = __instance.LOSLockedTarget;
                line.endColor = __instance.LOSLockedTarget;
                line.positionCount = 2;
                line.SetPosition(0, vector);
                Vector3 vector3 = vector - vector2;
                vector3.Normalize();
                vector3 *= __instance.LineEndOffset;
                vector2 += vector3;
                line.SetPosition(1, vector2);
                ReflectionHelper.InvokePrivateMethode(__instance, "SetEnemyTargetable", new object[] {target, true});
                List<AbstractActor> allActors = selectedActor.Combat.AllActors;
                allActors.Remove(selectedActor);
                allActors.Remove(targetActor);
                PathNode pathNode = default(PathNode);
                Vector3 attackPosition = default(Vector3);
                float num = default(float);
                selectedActor.Pathing.GetMeleeDestination(targetActor, allActors, out pathNode, out attackPosition,
                    out num);
                HUD.InWorldMgr.ShowAttackDirection(HUD.SelectedActor, targetActor,
                    HUD.Combat.HitLocation.GetAttackDirection(attackPosition, target), vector2.y,
                    MeleeAttackType.Punch, 0);
            }
            // not melee
            else
            {
                FiringPreviewManager.PreviewInfo previewInfo =
                    HUD.SelectionHandler.ActiveState.FiringPreview.GetPreviewInfo(target);
                if (previewInfo.availability == FiringPreviewManager.TargetAvailability.NotSet)
                {
                    Debug.LogError("Error - trying to draw line with no FiringPreviewManager availability!");
                }
                // why is the bad case first. just dump out of the fucking method, doug
                else
                {
                    bool flag = HUD.SelectionHandler.ActiveState.SelectionType != SelectionType.Sprint ||
                                HUD.SelectedActor.CanShootAfterSprinting;
                    bool flag2 = !isPositionLocked &&
                                 previewInfo.availability != FiringPreviewManager.TargetAvailability.BeyondMaxRange &&
                                 previewInfo.availability != FiringPreviewManager.TargetAvailability.BeyondRotation;
                    if (flag && (previewInfo.IsCurrentlyAvailable || flag2))
                    {
                        // multiple targets, even if only one selected
                        if (usingMultifire)
                        {
                            if (target == HUD.SelectedTarget)
                            {
                                LineRenderer lineRenderer = line;
                                Color color2 = lineRenderer.startColor =
                                    (line.endColor = __instance.LOSMultiTargetKBSelection);
                            }
                            else if (isLocked)
                            {
                                LineRenderer lineRenderer2 = line;
                                Color color2 =
                                    lineRenderer2.startColor = (line.endColor = __instance.LOSLockedTarget);
                            }
                            else
                            {
                                LineRenderer lineRenderer3 = line;
                                Color color2 =
                                    lineRenderer3.startColor = (line.endColor = __instance.LOSUnlockedTarget);
                            }
                        }
                        // normal shot
                        else
                        {
                            float shotQuality = (float) ReflectionHelper.InvokePrivateMethode(__instance,
                                "GetShotQuality", new object[] {selectedActor, position, rotation, target});
                            Color color5 = Color.Lerp(Color.clear, __instance.LOSInRange, shotQuality);
                            LineRenderer lineRenderer4 = line;
                            Color color2 = lineRenderer4.startColor = (line.endColor = color5);
                        }

                        line.material = __instance.MaterialInRange;
                        // straight line shot
                        if (previewInfo.HasLOF)
                        {
                            line.positionCount = 2;
                            line.SetPosition(0, vector);
                            Vector3 vector4 = vector - vector2;
                            vector4.Normalize();
                            vector4 *= __instance.LineEndOffset;
                            vector2 += vector4;
                            if (previewInfo.LOFLevel == LineOfFireLevel.LOFClear)
                            {
                                if (target == HUD.SelectionHandler.ActiveState.FacingEnemy)
                                {
                                    line.startWidth =
                                        __instance.LOSWidthBegin * __instance.LOSWidthFacingTargetMultiplier;
                                    line.endWidth = __instance.LOSWidthEnd * __instance.LOSWidthFacingTargetMultiplier;
                                }
                                else
                                {
                                    line.startWidth = __instance.LOSWidthBegin;
                                    line.endWidth = __instance.LOSWidthEnd;
                                }

                                line.SetPosition(1, vector2);
                            }
                            else
                            {
                                if (target == HUD.SelectionHandler.ActiveState.FacingEnemy)
                                {
                                    line.startWidth =
                                        __instance.LOSWidthBegin * __instance.LOSWidthFacingTargetMultiplier;
                                    line.endWidth =
                                        __instance.LOSWidthBegin * __instance.LOSWidthFacingTargetMultiplier;
                                }
                                else
                                {
                                    line.startWidth = __instance.LOSWidthBegin;
                                    line.endWidth = __instance.LOSWidthBegin;
                                }

                                Vector3 collisionPoint = previewInfo.collisionPoint;
                                collisionPoint = Vector3.Project(collisionPoint - vector, vector2 - vector) + vector;
                                line.SetPosition(1, collisionPoint);
                                LineRenderer line2 =
                                    (LineRenderer) ReflectionHelper.InvokePrivateMethode(__instance, "getLine",
                                        new object[] { });
                                line2.positionCount = 2;
                                line2.startWidth = __instance.LOSWidthBlocked;
                                line2.endWidth = __instance.LOSWidthBlocked;
                                line2.material = __instance.MaterialInRange;
                                LineRenderer lineRenderer5 = line2;
                                Color color2 = lineRenderer5.startColor = (line2.endColor = __instance.LOSBlocked);
                                line2.SetPosition(0, collisionPoint);
                                line2.SetPosition(1, vector2);
                                GameObject coverIcon =
                                    (GameObject) ReflectionHelper.InvokePrivateMethode(__instance, "getCoverIcon",
                                        new object[] { });
                                if (!coverIcon.activeSelf)
                                {
                                    coverIcon.SetActive(true);
                                }

                                coverIcon.transform.position = collisionPoint;
                            }
                        }
                        // arc shot
                        else
                        {
                            // other than formatting this block is the only thing that changed from the decompiled code
                            Vector3[] pointsForArc = WeaponRangeIndicators.GetPointsForArc(18, 30f, vector, vector2);
                            if (BTMLColorLOSMod.ModSettings.IndirectLineOfFireArcDashed)
                            {
                                line.material = __instance.MaterialOutOfRange;
                                line.material.color = BTMLColorLOSMod.ModSettings.IndirectLineOfFireArcColor;
                            }
                            else
                            { 
                                float shotQuality = (float) ReflectionHelper.InvokePrivateMethode(__instance,
                                    "GetShotQuality", new object[] {selectedActor, position, rotation, target});
                                // alright future me, this is probably destructive in some way, but 
                                // this lets us set the color of the line via that color6 bit.
                                line.material.color = Color.white;
                                Color color6 = Color.Lerp(
                                    Color.clear,
                                    BTMLColorLOSMod.ModSettings.IndirectLineOfFireArcColor, 
                                    shotQuality);
                                line.endColor = (line.startColor = color6);
                            }
                            line.positionCount = 18;
                            line.SetPositions(pointsForArc);
                        }

                        ReflectionHelper.InvokePrivateMethode(__instance, "SetEnemyTargetable",
                            new object[] {target, true});
                        if (targetActor != null)
                        {
                            HUD.InWorldMgr.ShowAttackDirection(HUD.SelectedActor, targetActor,
                                HUD.Combat.HitLocation.GetAttackDirection(position, target), vector2.y,
                                MeleeAttackType.NotSet, HUD.InWorldMgr.NumWeaponsTargeting(target));
                        }
                    }
                    // sprinted and can't shoot or out of rotation/weapon range
                    else
                    {
                        line.positionCount = 2;
                        line.SetPosition(0, vector);
                        line.SetPosition(1, vector2);
                        LineRenderer lineRenderer6 = line;
                        Color color2 = lineRenderer6.startColor = (line.endColor = __instance.LOSOutOfRange);
                        line.material = __instance.MaterialOutOfRange;
                        ReflectionHelper.InvokePrivateMethode(__instance, "SetEnemyTargetable",
                            new object[] {target, false});
                    }
                }
            }

            return false;
        }
    }
}