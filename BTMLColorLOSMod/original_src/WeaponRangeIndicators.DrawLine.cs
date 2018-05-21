// grabbed from VS Community with HBC Patch 1.0.3
using System.Collections.Generic;
using UnityEngine;

private void DrawLine (Vector3 position, Quaternion rotation, bool isPositionLocked, AbstractActor selectedActor, ICombatant target, bool usingMultifire, bool isLocked, bool isMelee)
{
	if (this.DEBUG_showLOSLines) {
		DEBUG_LOSLineDrawer debugDrawer = this.GetDebugDrawer ();
		debugDrawer.DrawLines (selectedActor, this.HUD.SelectionHandler.ActiveState, target);
	}
	LineRenderer line = this.getLine ();
	Vector3 vector = Vector3.Lerp (position, position + selectedActor.HighestLOSPosition, this.sourceLaserDestRatio);
	Vector3 vector2 = Vector3.Lerp (target.CurrentPosition, target.TargetPosition, this.targetLaserDestRatio);
	AbstractActor abstractActor = target as AbstractActor;
	if (isMelee) {
		line.startWidth = this.LOSWidthBegin;
		line.endWidth = this.LOSWidthEnd;
		line.material = this.MaterialInRange;
		line.startColor = this.LOSLockedTarget;
		line.endColor = this.LOSLockedTarget;
		line.positionCount = 2;
		line.SetPosition (0, vector);
		Vector3 vector3 = vector - vector2;
		vector3.Normalize ();
		vector3 *= this.LineEndOffset;
		vector2 += vector3;
		line.SetPosition (1, vector2);
		this.SetEnemyTargetable (target, true);
		List<AbstractActor> allActors = selectedActor.Combat.AllActors;
		allActors.Remove (selectedActor);
		allActors.Remove (abstractActor);
		PathNode pathNode = default(PathNode);
		Vector3 attackPosition = default(Vector3);
		float num = default(float);
		selectedActor.Pathing.GetMeleeDestination (abstractActor, allActors, out pathNode, out attackPosition, out num);
		this.HUD.InWorldMgr.ShowAttackDirection (this.HUD.SelectedActor, abstractActor, this.HUD.Combat.HitLocation.GetAttackDirection (attackPosition, target), vector2.y, MeleeAttackType.Punch, 0);
	} else {
		FiringPreviewManager.PreviewInfo previewInfo = this.HUD.SelectionHandler.ActiveState.FiringPreview.GetPreviewInfo (target);
		if (previewInfo.availability == FiringPreviewManager.TargetAvailability.NotSet) {
			Debug.LogError ("Error - trying to draw line with no FiringPreviewManager availability!");
		} else {
			bool flag = this.HUD.SelectionHandler.ActiveState.SelectionType != SelectionType.Sprint || this.HUD.SelectedActor.CanShootAfterSprinting;
			bool flag2 = !isPositionLocked && previewInfo.availability != FiringPreviewManager.TargetAvailability.BeyondMaxRange && previewInfo.availability != FiringPreviewManager.TargetAvailability.BeyondRotation;
			if (flag && (previewInfo.IsCurrentlyAvailable || flag2)) {
				if (usingMultifire) {
					if (target == this.HUD.SelectedTarget) {
						LineRenderer lineRenderer = line;
						Color color2 = lineRenderer.startColor = (line.endColor = this.LOSMultiTargetKBSelection);
					} else if (isLocked) {
						LineRenderer lineRenderer2 = line;
						Color color2 = lineRenderer2.startColor = (line.endColor = this.LOSLockedTarget);
					} else {
						LineRenderer lineRenderer3 = line;
						Color color2 = lineRenderer3.startColor = (line.endColor = this.LOSUnlockedTarget);
					}
				} else {
					float shotQuality = this.GetShotQuality (selectedActor, position, rotation, target);
					Color color5 = Color.Lerp (Color.clear, this.LOSInRange, shotQuality);
					LineRenderer lineRenderer4 = line;
					Color color2 = lineRenderer4.startColor = (line.endColor = color5);
				}
				line.material = this.MaterialInRange;
				if (previewInfo.HasLOF) {
					line.positionCount = 2;
					line.SetPosition (0, vector);
					Vector3 vector4 = vector - vector2;
					vector4.Normalize ();
					vector4 *= this.LineEndOffset;
					vector2 += vector4;
					if (previewInfo.LOFLevel == LineOfFireLevel.LOFClear) {
						if (target == this.HUD.SelectionHandler.ActiveState.FacingEnemy) {
							line.startWidth = this.LOSWidthBegin * this.LOSWidthFacingTargetMultiplier;
							line.endWidth = this.LOSWidthEnd * this.LOSWidthFacingTargetMultiplier;
						} else {
							line.startWidth = this.LOSWidthBegin;
							line.endWidth = this.LOSWidthEnd;
						}
						line.SetPosition (1, vector2);
					} else {
						if (target == this.HUD.SelectionHandler.ActiveState.FacingEnemy) {
							line.startWidth = this.LOSWidthBegin * this.LOSWidthFacingTargetMultiplier;
							line.endWidth = this.LOSWidthBegin * this.LOSWidthFacingTargetMultiplier;
						} else {
							line.startWidth = this.LOSWidthBegin;
							line.endWidth = this.LOSWidthBegin;
						}
						Vector3 collisionPoint = previewInfo.collisionPoint;
						collisionPoint = Vector3.Project (collisionPoint - vector, vector2 - vector) + vector;
						line.SetPosition (1, collisionPoint);
						LineRenderer line2 = this.getLine ();
						line2.positionCount = 2;
						line2.startWidth = this.LOSWidthBlocked;
						line2.endWidth = this.LOSWidthBlocked;
						line2.material = this.MaterialInRange;
						LineRenderer lineRenderer5 = line2;
						Color color2 = lineRenderer5.startColor = (line2.endColor = this.LOSBlocked);
						line2.SetPosition (0, collisionPoint);
						line2.SetPosition (1, vector2);
						GameObject coverIcon = this.getCoverIcon ();
						if (!coverIcon.activeSelf) {
							coverIcon.SetActive (true);
						}
						coverIcon.transform.position = collisionPoint;
					}
				} else {
					Vector3[] pointsForArc = WeaponRangeIndicators.GetPointsForArc (18, 30f, vector, vector2);
					line.positionCount = 18;
					line.SetPositions (pointsForArc);
				}
				this.SetEnemyTargetable (target, true);
				if (abstractActor != null) {
					this.HUD.InWorldMgr.ShowAttackDirection (this.HUD.SelectedActor, abstractActor, this.HUD.Combat.HitLocation.GetAttackDirection (position, target), vector2.y, MeleeAttackType.NotSet, this.HUD.InWorldMgr.NumWeaponsTargeting (target));
				}
			} else {
				line.positionCount = 2;
				line.SetPosition (0, vector);
				line.SetPosition (1, vector2);
				LineRenderer lineRenderer6 = line;
				Color color2 = lineRenderer6.startColor = (line.endColor = this.LOSOutOfRange);
				line.material = this.MaterialOutOfRange;
				this.SetEnemyTargetable (target, false);
			}
		}
	}
}
