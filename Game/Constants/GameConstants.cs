namespace MainGame
{
public static class GameConstants
{
    //Game1.cs
    public const int BackBufferWidth = 768;
    public const int BackBufferHeight = 696;
    public const int PlayerStartPositionX = 96;
    public const int PlayerStartPositionY = 96;
    //PushableBlock.cs
    public const int MaxPushDuration = 25;
    public const int PushableBlockSpeed = 1;
    public const int MaxNotCollisionTimer = 5;
    public const bool InitialCanPush = true; // TODO: make false after testing
    public const bool InitialIsBeingPushed = false;
    //EnemyPlayerProjectileCollisionHandler.cs
    public const int EnemyStunDuration = 100;
    //BottomFullHorizontalWallHitBox.cs
    public const int BottomFullHorizontalWallX = 0;
    public const int BottomFullHorizontalWallY = 9;
    public const int BottomFullHorizontalWallWidth = 16;
    public const int BottomFullHorizontalWallHeight = 2;
    //BottomHorizontalDoorWallHitBox.cs
    public const int BottomHorizontalDoorWallX = 0;
    public const int BottomHorizontalDoorWallYFactor = 9;
    public const float BottomHorizontalDoorWallWidthFactor = 7.5f;
    public const int BottomHorizontalDoorWallHeightFactor = 2;
    //LeftFullVerticalWallHitBox.cs
    public const int WallX = 0;
    public const int WallY = 0;
    public const int LeftWallWidth = 32;
    public const int LeftWallHeight = 176;
    //LeftFullVerticalWallHitBox.cs
    public const int LeftFullVerticalWallX = 0;
    public const int LeftFullVerticalWallY = 0;
    public const int LeftFullVerticalWallWidth = 32;
    public const int LeftFullVerticalWallHeight = 176;
    //LeftVerticalDoorWallHitBox.cs
    public const int LeftVerticalDoorWallX = 0;
    public const int LeftVerticalDoorWallY = 0;
    public const int LeftVerticalDoorWallWidth = 2;
    public const int LeftVerticalDoorWallTopHeight = 5;
    public const int LeftVerticalDoorWallBottomHeight = 5;
    //RightFullVerticalWallHitBox.cs
    public const int RightFullVerticalWallX=14;
    public const int RightFullVerticalWallWidth = 2;
    public const int RightFullVerticalWallHeight = 11;
    //RightVerticalDoorWallHitBox.cs
    public const int RightVerticalDoorWallXFactor = 14;
    public const int RightVerticalDoorWallY = 0;
    public const int RightVerticalDoorWallWidth = 2;
    public const int RightVerticalDoorWallTopHeight = 5;
    public const int RightVerticalDoorWallBottomHeight = 5;
    //TopFullHorizontalWallHitBox.cs
    public const int TopFullHorizontalWallX = 0;
    public const int TopFullHorizontalWallY = 0;
    public const int TopFullHorizontalWallWidth = 16;
    public const int TopFullHorizontalWallHeight = 2;
    //TopHorizontalDoorWallHitBox.cs
    public const int TopHorizontalDoorWallX = 0;
    public const int TopHorizontalDoorWallY = 0;
    public const float TopHorizontalDoorWallWidthFactor = 7.5f;
    public const int TopHorizontalDoorWallHeight = 2;
    //Door.cs
    public const int InitialOffsetX = 0;
    public const int InitialOffsetY = 0;
    public const float TopSpriteLayerDepth = 0f;
    public const float BottomSpriteLayerDepth = 1.0f;
    public const int DoorOffsetFactor = 16;
    //AquamentusAttackingState.cs
    public const int AquamentusAttackDuration = 32;
    public const int AquamentusMouthPositionXOffset = 16;
    public const int AquamentusMouthPositionYOffset = 12;
    //AquamentusEnemy.cs
    public const int InitialMovedDistance = 0;
    public const int AquamentusMovementCoolDownFrame = 8;
    public const int AquamentusMaxMoveDistanceFactor = 16;
    public const int AquamentusMaxMoveDistanceMultiplier = 10;
    //AquamentusMovingState.cs
    public const int InitialMoveDuration = 0;
    public const int AquamentusMaxMoveDuration = 67;
    public const int AquamentusAttackProbability = 2;
    //GelEnemy.cs
    public const int GelHitboxHeightFactor = 2;
    public const int GelHitboxWidthFactor = 2;
    public const int GelMovementCoolDownFrame = 1;
    //GelIdleState.cs
    public const int GelIdleStateDurationMin = 0;
    public const int GelIdleStateDurationMax = 8;
    public const int GelIdleStateDurationFactor = 16;
    //GelMovingState.cs
    public const int GelMovingStateDuration = 15;
    //GoriyaEnemy.cs
    public const int GoriyaMovementCoolDownFrame = 2;
    //GoriyaMovingState.cs
    public const int GoriyaMaxMoveDuration = 31;
    public const int GoriyaBoomerangProbability = 12;
    //KeeseEnemy.cs
    public const int KeeseHitboxHeightFactor = 2;
    public const int KeeseMovementCoolDownFrame = 1;
    //KeeseFlyingState.cs
    public const int KeeseFlightDurationMin = 1;
    public const int KeeseFlightDurationMax = 64;
    public const int KeeseFlightDurationFactor = 16;
    public const int KeeseDirectionChangeMin = 1;
    public const int KeeseDirectionChangeMax = 16;
    public const int KeeseDirectionChangeFactor = 4;
    //KeeseLandedState.cs
    public const int KeeseLandDurationMin = 5;
    public const int KeeseLandDurationMax = 20;
    public const int KeeseLandDurationFactor = 10;
    //KeeseLandingState.cs
    public const int KeeseLandingStateHalf = 2;
    public const int KeeseLandingStateMoveSlow = 8;
    public const int KeeseLandingStateMoveFast = 4;
    //KeeseTakeOffState.cs
    public const int KeeseTakeOffStateHalf = 2;
    public const int KeeseTakeOffStateMoveSlow = 8;
    public const int KeeseTakeOffStateMoveFast = 4;
    //OldManEnemy.cs
    public const int OldManMovementCoolDownFrame = 0;
    //SpikeCrossEnemy.cs
    public const int SpikeCrossMovementCoolDownFrame = 1;
    //SpikeCrossIdleState.cs
    public const int SpikeCrossIdleStateMoveTrigger = 48;
    //SpikeCrossMovingState.cs
    public const int SpikeCrossMoveDistanceFactor1 = 48;
    public const int SpikeCrossMoveDistanceFactor2 = 3;
    public const int SpikeCrossMoveDistanceFactor3 = 24;
    public const int SpikeCrossForwardSpeed = 4;
    public const int SpikeCrossReturnSpeed = 2;
    //StalfosEnemy.cs
    public const int StalfosMovementCoolDownFrame = 2;
    public const int StalfosMaxMoveDuration = 32;
    //WallMasterEnemy.cs
    public const int WallMasterMovementCoolDownFrame = 1;
    //GenericEnemy.cs
    public const int GenericEnemyImmunityFrame = 10;
    public const float GenericEnemyKnockBackSpeed = 10f;
    public const int GenericEnemyInitialInvulnerableTimer = 0;
    public const int GenericEnemyInitialStunDuration = 0;
    public const float GenericEnemyInitialKnockedBackDistance = 0f;
    public const int GenericEnemyFlashColorFactor = 4;
    //GridHandler.cs
    public const int GridStartValue = 0;
    public const int CellSizeFactor = 16;
    public const int FullStepDivisor = 2;
    public const int HalfStepDivisor = 4;
    //SwordBeamExplodingParticles.cs
    public const int SwordBeamParticleMoveSpeed = 5;
    public const int SwordBeamParticleLifetime = 10;
    //Player.cs
    public const int PlayerSpeedIncrease = 2;
    public const int PlayerUsingItemsSpeed = 6;
    public const float PlayerKnockedBackSpeed = 10f;
    public const int PlayerImmunityFrame = 100;
    public const int PlayerKnockedBackDistanceFactor = 2;
    public const int PlayerFlashColorFactor = 4;
    public const int PlayerHitBoxDivisor = 2;
    //Player/AttackStates
    public const int AttackStateInitialCurrentFrame = 0;
    //AquamentusBaseProjectile.cs
    public const int AquamentusProjectileInitialMovementDuration = 20;
    public const int AquamentusProjectileMovementDuration = 500;
    public const float AquamentusProjectileInitialMovementSpeed = 1f;
    public const int AquamentusProjectileMainMovementSpeedFactor = 2;
    public const double AquamentusProjectileProjectionOffsetFactor = 15d;
    public const double AquamentusProjectileProjectionOffsetDivisor = 180d;
    //ArrowProjectile.cs
    public const float ArrowProjectileMaxDistanceTravel = 1000f;
    public const float ArrowProjectileSpeed = 15f;
    public const int ArrowProjectileCollisionTimer = 10;
    public const float ArrowProjectileInitialChange = 0f;
    //BombProjectile.cs
    public const int BombProjectileSpawnOffset = 48;
    public const int BombProjectileDetonationCountdown = 64;
    public const int BombProjectileDetonationHeightFactor = 5;
    public const int BombProjectileDetonationWidthFactor = 3;
    public const int BombProjectileDetonationDivisor = 2;
    public const int BombProjectileExplosionHeightFactor = 3;
    public const int BombProjectileExplosionDivisor = 4;
    public const int BombProjectileInitialExplosionTime = 0;
    public const int BombProjectileDrawExplosionDivisor = 2;
    //BoomerangProjectile.cs
    public const int BoomerangProjectileCollideSpriteDuration = 10;
    public const float BoomerangProjectileAcceleration = 0.02f;
    public const float BoomerangProjectileInitialSpeed = 10f;
    public const float BoomerangProjectileReturnDistance = 10f;
    public const int BoomerangProjectileHitBoxDivisor = 2;
    public const bool BoomerangProjectileInitialShowCollideSprite = false;
    public const bool BoomerangProjectileInitialIsActive = true;
    public const bool BoomerangProjectileInitialReturning = false;
    public const int BoomerangProjectileInitialTimer = 0;
    //FireBallProjectile.cs
    public const int FireBallProjectileInitialIdleTime = 100;
    public const float FireBallProjectileSpeed = 1f;
    public const float FireBallProjectileInitialChange = 0f;
    //PlayerBoomerangProjectile.cs
    public const int PlayerBoomerangProjectileCollideSpriteDuration = 10;
    public const float PlayerBoomerangProjectileAcceleration = 0.02f;
    public const float PlayerBoomerangProjectileInitialSpeed = 10f;
    public const int PlayerBoomerangProjectileHitBoxDivisor = 2;
    public const float PlayerBoomerangProjectileReturnDistance = 10f;
    public const int PlayerBoomerangProjectileInitialTimer = 0;
    public const bool PlayerBoomerangProjectileInitialShowCollideSprite = false;
    public const bool PlayerBoomerangProjectileInitialIsActive = true;
    public const bool PlayerBoomerangProjectileInitialReturning = false;
    //SwordBeamProjectile.cs
    public const float SwordBeamProjectileMaxDistanceTravel = float.MaxValue;
    public const float SwordBeamProjectileSpeed = 10f;
    public const int SwordBeamProjectileHitBoxDivisor = 2;
    public const int SwordBeamProjectileInitialDirectionVector = 0;
    public const int SwordBeamProjectileNorthDirectionVector = -1;
    public const int SwordBeamProjectileSouthDirectionVector = 1;
    public const int SwordBeamProjectileEastDirectionVector = 1;
    public const int SwordBeamProjectileWestDirectionVector = -1;
    public const bool SwordBeamProjectileInitialExploding = false;
    public const bool SwordBeamProjectileInitialIsActive = true;
    //GameRoomManager.cs
    public const int GameRoomManagerInitialRoomIndex = 0;
    public const int GameRoomManagerInitialRoomChangeDebounce = 20;
    //Room.cs
    public const int RoomInitialPosition = 0;
    public const float RoomOuterBorderSpriteLayerDepth = 0f;
    public const float RoomInnerBorderSpriteLayerDepth = 1.0f;
    public const float RoomTilesSpriteLayerDepth = 1.0f;
    //RoomFactory.cs
    public const int RoomFactoryWallOffsetX = 32;
    public const int RoomFactoryWallOffsetY = 32;
    public const int RoomFactoryColumnWidth = 16;
    //BlockSprite.cs
    public const int BlockSpriteDefaultSpriteHeight = 16;
    public const int BlockSpriteDefaultSpriteWidth = 16;
    public const int BlockSpriteDefaultTextureStartingX = 0;
    public const int BlockSpriteDefaultTextureStartingY = 0;
    public const int BlockSpriteDefaultScale = 1;
    public const float BlockSpriteDefaultLayerDepth = 0.5f;
    public const int BlockSpriteDefaultOrigin = 0;
    //DoorSegmentNorthSouth.cs
    public const int DoorSegmentNorthSouthDefaultSpriteHeight = 16;
    public const int DoorSegmentNorthSouthDefaultSpriteWidth = 32;
    public const int DoorSegmentNorthSouthDefaultTextureStartingX = 0;
    public const int DoorSegmentNorthSouthDefaultTextureStartingY = 0;
    public const int DoorSegmentNorthSouthDefaultScale = 1;
    public const float DoorSegmentNorthSouthDefaultLayerDepth = 0.5f;
    public const int DoorSegmentNorthSouthDefaultOrigin = 0;
    public const float DoorSegmentNorthSouthDefaultRotation = 0f;
    //DoorSegmentEastWest.cs
    public const int DoorSegmentWestEastDefaultSpriteHeight = 32;
    public const int DoorSegmentWestEastDefaultSpriteWidth = 16;
    public const int DoorSegmentWestEastDefaultTextureStartingX = 0;
    public const int DoorSegmentWestEastDefaultTextureStartingY = 0;
    public const int DoorSegmentWestEastDefaultScale = 1;
    public const float DoorSegmentWestEastDefaultLayerDepth = 0.5f;
    public const int DoorSegmentWestEastDefaultOrigin = 0;
    public const float DoorSegmentWestEastDefaultRotation = 0f;
    //AquamentusAttackingSprite.cs
    public const int AquamentusAttackingSpriteDefaultFrameHeight = 16;
    public const int AquamentusAttackingSpriteDefaultFrameWidth = 16;
    public const int AquamentusAttackingSpriteDefaultTextureStartingX = 0;
    public const int AquamentusAttackingSpriteDefaultTextureStartingY = 0;
    public const int AquamentusAttackingSpriteDefaultScale = 1;
    public const float AquamentusAttackingSpriteDefaultLayerDepth = 0f;
    public const int AquamentusAttackingSpriteInitialDisplayTimeLapse = 0;
    public const int AquamentusAttackingSpriteInitialFrame = 0;
    public const int AquamentusAttackingSpriteNextFrame = 1;
    public const int AquamentusAttackingSpriteFrameDisplayTime = 16;
    //AquamentusAttackProjectileSprite.cs
    public const int AquamentusAttackProjectileSpriteDefaultFrameHeight = 16;
    public const int AquamentusAttackProjectileSpriteDefaultFrameWidth = 16;
    public const int AquamentusAttackProjectileSpriteDefaultTextureStartingX = 0;
    public const int AquamentusAttackProjectileSpriteDefaultTextureStartingY = 0;
    public const int AquamentusAttackProjectileSpriteDefaultScale = 1;
    public const float AquamentusAttackProjectileSpriteDefaultLayerDepth = 0.5f;
    public const int AquamentusAttackProjectileSpriteInitialDisplayTimeLapse = 0;
    public const int AquamentusAttackProjectileSpriteInitialFrame = 0;
    public const int AquamentusAttackProjectileSpriteNextFrame1 = 1;
    public const int AquamentusAttackProjectileSpriteNextFrame2 = 2;
    public const int AquamentusAttackProjectileSpriteNextFrame3 = 3;
    public const int AquamentusAttackProjectileSpriteFrameDisplayTime = 1;
    //AquamentusSprite.cs
    public const int AquamentusSpriteDefaultFrameHeight = 16;
    public const int AquamentusSpriteDefaultFrameWidth = 16;
    public const int AquamentusSpriteDefaultTextureStartingX = 0;
    public const int AquamentusSpriteDefaultTextureStartingY = 0;
    public const int AquamentusSpriteDefaultScale = 1;
    public const float AquamentusSpriteDefaultLayerDepth = 0.5f;
    public const int AquamentusSpriteInitialDisplayTimeLapse = 0;
    public const int AquamentusSpriteInitialFrame = 0;
    public const int AquamentusSpriteNextFrame = 1;
    public const int AquamentusSpriteFrameDisplayTime = 16;
    //GoriyaWalkingDownSprite.cs
    public const int GoriyaWalkingDownSpriteDefaultFrameHeight = 16;
    public const int GoriyaWalkingDownSpriteDefaultFrameWidth = 16;
    public const int GoriyaWalkingDownSpriteDefaultTextureStartingX = 0;
    public const int GoriyaWalkingDownSpriteDefaultTextureStartingY = 0;
    public const int GoriyaWalkingDownSpriteDefaultScale = 1;
    public const float GoriyaWalkingDownSpriteDefaultLayerDepth = 0.5f;
    public const int GoriyaWalkingDownSpriteInitialDisplayTimeLapse = 0;
    public const bool GoriyaWalkingDownSpriteInitialFlip = false;
    public const int GoriyaWalkingDownSpriteInitialFrame = 0;
    public const int GoriyaWalkingDownSpriteNextFrame = 1;
    public const int GoriyaWalkingDownSpriteFrameDisplayTime = 6;
    //GoriyaWalkingLeftSprite.cs
    public const int GoriyaWalkingLeftSpriteDefaultFrameHeight = 16;
    public const int GoriyaWalkingLeftSpriteDefaultFrameWidth = 16;
    public const int GoriyaWalkingLeftSpriteDefaultTextureStartingX = 0;
    public const int GoriyaWalkingLeftSpriteDefaultTextureStartingY = 0;
    public const int GoriyaWalkingLeftSpriteDefaultScale = 1;
    public const float GoriyaWalkingLeftSpriteDefaultLayerDepth = 0.5f;
    public const int GoriyaWalkingLeftSpriteInitialDisplayTimeLapse = 0;
    public const int GoriyaWalkingLeftSpriteInitialFrame = 0;
    public const int GoriyaWalkingLeftSpriteNextFrame = 1;
    public const int GoriyaWalkingLeftSpriteFrameDisplayTime = 6;
    //GoriyaWalkingRightSprite.cs
    public const int GoriyaWalkingRightSpriteDefaultFrameHeight = 16;
    public const int GoriyaWalkingRightSpriteDefaultFrameWidth = 16;
    public const int GoriyaWalkingRightSpriteDefaultTextureStartingX = 0;
    public const int GoriyaWalkingRightSpriteDefaultTextureStartingY = 0;
    public const int GoriyaWalkingRightSpriteDefaultScale = 1;
    public const float GoriyaWalkingRightSpriteDefaultLayerDepth = 0.5f;
    public const int GoriyaWalkingRightSpriteInitialDisplayTimeLapse = 0;
    public const int GoriyaWalkingRightSpriteInitialFrame = 0;
    public const int GoriyaWalkingRightSpriteNextFrame = 1;
    public const int GoriyaWalkingRightSpriteFrameDisplayTime = 6;
    //GoriyaWalkingUpSprite.cs
    public const int GoriyaWalkingUpSpriteDefaultFrameHeight = 16;
    public const int GoriyaWalkingUpSpriteDefaultFrameWidth = 16;
    public const int GoriyaWalkingUpSpriteDefaultTextureStartingX = 0;
    public const int GoriyaWalkingUpSpriteDefaultTextureStartingY = 0;
    public const int GoriyaWalkingUpSpriteDefaultScale = 1;
    public const float GoriyaWalkingUpSpriteDefaultLayerDepth = 0.5f;
    public const int GoriyaWalkingUpSpriteInitialDisplayTimeLapse = 0;
    public const bool GoriyaWalkingUpSpriteInitialFlip = false;
    public const int GoriyaWalkingUpSpriteInitialFrame = 0;
    public const int GoriyaWalkingUpSpriteNextFrame = 1;
    public const int GoriyaWalkingUpSpriteFrameDisplayTime = 6;
    //KeeseFlightSprite.cs
    public const int KeeseFlightSpriteDefaultFrameHeight = 16;
    public const int KeeseFlightSpriteDefaultFrameWidth = 16;
    public const int KeeseFlightSpriteDefaultTextureStartingX = 0;
    public const int KeeseFlightSpriteDefaultTextureStartingY = 0;
    public const int KeeseFlightSpriteDefaultScale = 1;
    public const float KeeseFlightSpriteDefaultLayerDepth = 0.5f;
    public const int KeeseFlightSpriteInitialDisplayTimeLapse = 0;
    public const int KeeseFlightSpriteInitialFrame = 0;
    public const int KeeseFlightSpriteNextFrame = 1;
    public const int KeeseFlightSpriteFrameDisplayTime = 3;
    //KeeseLandedSprite.cs
    public const int KeeseLandedSpriteDefaultSpriteHeight = 16;
    public const int KeeseLandedSpriteDefaultSpriteWidth = 16;
    public const int KeeseLandedSpriteDefaultTextureStartingX = 0;
    public const int KeeseLandedSpriteDefaultTextureStartingY = 0;
    public const int KeeseLandedSpriteDefaultScale = 1;
    public const float KeeseLandedSpriteDefaultLayerDepth = 0.5f;
    //KeeseLandingSprite.cs
    public const int KeeseLandingSpriteDefaultFrameHeight = 16;
    public const int KeeseLandingSpriteDefaultFrameWidth = 16;
    public const int KeeseLandingSpriteDefaultTextureStartingX = 0;
    public const int KeeseLandingSpriteDefaultTextureStartingY = 0;
    public const int KeeseLandingSpriteDefaultScale = 1;
    public const float KeeseLandingSpriteDefaultLayerDepth = 0.5f;
    //KeeseTakeOffSprite.cs
    public const int KeeseTakeOffSpriteDefaultFrameHeight = 16;
    public const int KeeseTakeOffSpriteDefaultFrameWidth = 16;
    public const int KeeseTakeOffSpriteDefaultTextureStartingX = 0;
    public const int KeeseTakeOffSpriteDefaultTextureStartingY = 0;
    public const int KeeseTakeOffSpriteDefaultScale = 1;
    public const float KeeseTakeOffSpriteDefaultLayerDepth = 0.5f;
    //GelSprite.cs
    public const int GelSpriteDefaultFrameHeight = 16;
    public const int GelSpriteDefaultFrameWidth = 16;
    public const int GelSpriteDefaultTextureStartingX = 0;
    public const int GelSpriteDefaultTextureStartingY = 0;
    public const int GelSpriteDefaultScale = 1;
    public const float GelSpriteDefaultLayerDepth = 0.5f;
    public const int GelSpriteInitialDisplayTimeLapse = 0;
    public const int GelSpriteInitialFrame = 0;
    public const int GelSpriteNextFrame = 1;
    public const int GelSpriteFrameDisplayTime = 2;
    //OldManSprite.cs
    public const int OldManSpriteDefaultSpriteHeight = 16;
    public const int OldManSpriteDefaultSpriteWidth = 16;
    public const int OldManSpriteDefaultTextureStartingX = 0;
    public const int OldManSpriteDefaultTextureStartingY = 0;
    public const int OldManSpriteDefaultScale = 1;
    public const float OldManSpriteDefaultLayerDepth = 0.5f;
    //SpikeCrossSprite.cs
    public const int SpikeCrossSpriteDefaultSpriteHeight = 16;
    public const int SpikeCrossSpriteDefaultSpriteWidth = 16;
    public const int SpikeCrossSpriteDefaultTextureStartingX = 0;
    public const int SpikeCrossSpriteDefaultTextureStartingY = 0;
    public const int SpikeCrossSpriteDefaultScale = 1;
    public const float SpikeCrossSpriteDefaultLayerDepth = 0.5f;
    //StalfosSprite.cs
    public const int StalfosSpriteDefaultFrameHeight = 16;
    public const int StalfosSpriteDefaultFrameWidth = 16;
    public const int StalfosSpriteDefaultTextureStartingX = 0;
    public const int StalfosSpriteDefaultTextureStartingY = 0;
    public const int StalfosSpriteDefaultScale = 1;
    public const float StalfosSpriteDefaultLayerDepth = 0.5f;
    public const int StalfosSpriteInitialDisplayTimeLapse = 0;
    public const bool StalfosSpriteInitialFlipState = false;
    public const int StalfosSpriteInitialFrame = 0;
    public const int StalfosSpriteNextFrame = 1;
    public const int StalfosSpriteFrameDisplayTime = 8;
    //WallMasterSprite.cs
    public const int WallMasterSpriteDefaultFrameHeight = 16;
    public const int WallMasterSpriteDefaultFrameWidth = 16;
    public const int WallMasterSpriteDefaultTextureStartingX = 0;
    public const int WallMasterSpriteDefaultTextureStartingY = 0;
    public const int WallMasterSpriteDefaultScale = 1;
    public const float WallMasterSpriteDefaultLayerDepth = 0.5f;
    public const int WallMasterSpriteInitialDisplayTimeLapse = 0;
    public const int WallMasterSpriteInitialFrame = 0;
    public const int WallMasterSpriteNextFrame = 1;
    public const int WallMasterSpriteFrameDisplayTime = 8;
    //FairyItemSprite.cs
    public const int FairyItemSpriteDefaultFrameHeight = 16;
    public const int FairyItemSpriteDefaultFrameWidth = 16;
    public const int FairyItemSpriteDefaultTextureStartingX = 0;
    public const int FairyItemSpriteDefaultTextureStartingY = 0;
    public const int FairyItemSpriteDefaultScale = 1;
    public const float FairyItemSpriteDefaultLayerDepth = 0.5f;
    public const int FairyItemSpriteInitialDisplayTimeLapse = 0;
    public const int FairyItemSpriteInitialFrame = 0;
    public const int FairyItemSpriteNextFrame = 1;
    public const int FairyItemSpriteFrameDisplayTime = 4;
    //FireSprite.cs
    public const int FireSpriteDefaultFrameHeight = 16;
    public const int FireSpriteDefaultFrameWidth = 16;
    public const int FireSpriteDefaultTextureStartingX = 0;
    public const int FireSpriteDefaultTextureStartingY = 0;
    public const int FireSpriteDefaultScale = 1;
    public const float FireSpriteDefaultLayerDepth = 0.5f;
    public const int FireSpriteInitialDisplayTimeLapse = 0;
    public const bool FireSpriteInitialFlipState = false;
    public const int FireSpriteInitialFrame = 0;
    public const int FireSpriteNextFrame = 1;
    public const int FireSpriteFrameDisplayTime = 6;
    //HeartItemSprite.cs
    public const int HeartItemSpriteDefaultFrameHeight = 16;
    public const int HeartItemSpriteDefaultFrameWidth = 16;
    public const int HeartItemSpriteDefaultTextureStartingX = 0;
    public const int HeartItemSpriteDefaultTextureStartingY = 0;
    public const int HeartItemSpriteDefaultScale = 1;
    public const float HeartItemSpriteDefaultLayerDepth = 0.5f;
    public const int HeartItemSpriteInitialDisplayTimeLapse = 0;
    public const int HeartItemSpriteInitialFrame = 0;
    public const int HeartItemSpriteNextFrame = 1;
    public const int HeartItemSpriteFrameDisplayTime = 8;
    //RupeeItemSprite.cs
    public const int RupeeItemSpriteDefaultFrameHeight = 16;
    public const int RupeeItemSpriteDefaultFrameWidth = 16;
    public const int RupeeItemSpriteDefaultTextureStartingX = 0;
    public const int RupeeItemSpriteDefaultTextureStartingY = 0;
    public const int RupeeItemSpriteDefaultScale = 1;
    public const float RupeeItemSpriteDefaultLayerDepth = 0.5f;
    public const int RupeeItemSpriteInitialDisplayTimeLapse = 0;
    public const int RupeeItemSpriteInitialFrame = 0;
    public const int RupeeItemSpriteNextFrame = 1;
    public const int RupeeItemSpriteFrameDisplayTime = 8;
    //StaticItemSprite.cs
    public const int StaticItemSpriteDefaultSpriteHeight = 16;
    public const int StaticItemSpriteDefaultSpriteWidth = 16;
    public const int StaticItemSpriteDefaultTextureStartingX = 0;
    public const int StaticItemSpriteDefaultTextureStartingY = 0;
    public const int StaticItemSpriteDefaultScale = 1;
    public const float StaticItemSpriteDefaultLayerDepth = 0.5f;
    //TriforcePieceItemSprite.cs
    public const int TriforcePieceItemSpriteDefaultFrameHeight = 16;
    public const int TriforcePieceItemSpriteDefaultFrameWidth = 16;
    public const int TriforcePieceItemSpriteDefaultTextureStartingX = 0;
    public const int TriforcePieceItemSpriteDefaultTextureStartingY = 0;
    public const int TriforcePieceItemSpriteDefaultScale = 1;
    public const float TriforcePieceItemSpriteDefaultLayerDepth = 0.5f;
    public const int TriforcePieceItemSpriteInitialDisplayTimeLapse = 0;
    public const int TriforcePieceItemSpriteInitialFrame = 0;
    public const int TriforcePieceItemSpriteNextFrame = 1;
    public const int TriforcePieceItemSpriteFrameDisplayTime = 8;
    //DeathParticle.cs
    public const int DeathParticleDefaultFrameHeight = 16;
    public const int DeathParticleDefaultFrameWidth = 16;
    public const int DeathParticleDefaultTextureStartingX = 0;
    public const int DeathParticleDefaultTextureStartingY = 0;
    public const int DeathParticleDefaultScale = 1;
    public const float DeathParticleDefaultLayerDepth = 0.5f;
    public const int DeathParticleInitialDisplayTimeLapse = 0;
    public const int DeathParticleInitialFrame = 0;
    public const int DeathParticleNextFrame = 1;
    public const int DeathParticleFrameDisplayTime = 6;
    //SpawnParticle.cs
    public const int SpawnParticleDefaultTextureStartingX = 0;
    public const int SpawnParticleDefaultTextureStartingY = 0;
    public const int SpawnParticleDefaultScale = 1;
    public const float SpawnParticleDefaultLayerDepth = 0.5f;
    public const int SpawnParticleInitialDisplayTimeLapse = 0;
    public const int SpawnParticleInitialFrame = 0;
    public const int SpawnParticleNextFrame1 = 1;
    public const int SpawnParticleNextFrame2 = 2;
    public const int SpawnParticleInitialFrameDisplayTime = 3;
    public const int SpawnParticleNextFrameDisplayTime = 6;
    //SwordBeamParticle.cs
    public const int SwordBeamParticleDefaultTextureStartingX = 0;
    public const int SwordBeamParticleDefaultTextureStartingY = 0;
    public const int SwordBeamParticleDefaultScale = 1;
    public const float SwordBeamParticleDefaultLayerDepth = 0.5f;
    public const int SwordBeamParticleInitialDisplayTimeLapse = 0;
    public const int SwordBeamParticleInitialFrame = 0;
    public const int SwordBeamParticleNextFrame1 = 1;
    public const int SwordBeamParticleNextFrame2 = 2;
    public const int SwordBeamParticleNextFrame3 = 3;
    public const int SwordBeamParticleFrameDisplayTime = 1;
    //PlayerAttackingDownSprite.cs
    public const int PlayerAttackingDownSpriteDefaultFrameHeight = 16;
    public const int PlayerAttackingDownSpriteDefaultFrameWidth = 16;
    public const int PlayerAttackingDownSpriteDefaultTextureStartingX = 0;
    public const int PlayerAttackingDownSpriteDefaultTextureStartingY = 0;
    public const int PlayerAttackingDownSpriteDefaultScale = 1;
    public const float PlayerAttackingDownSpriteDefaultLayerDepth = 0.5f;
    public const int PlayerAttackingDownSpriteInitialDisplayTimeLapse = 0;
    public const int PlayerAttackingDownSpriteInitialFrame = 0;
    public const int PlayerAttackingDownSpriteNextFrame1 = 1;
    public const int PlayerAttackingDownSpriteNextFrame2 = 2;
    public const int PlayerAttackingDownSpriteNextFrame3 = 3;
    public const int PlayerAttackingDownSpriteInitialFrameDisplayTime = 4;
    public const int PlayerAttackingDownSpriteNextFrame1DisplayTime = 8;
    public const int PlayerAttackingDownSpriteNextFrameDisplayTime = 1;
    //PlayerAttackingLeftSprite.cs
    public const int PlayerAttackingLeftSpriteDefaultFrameHeight = 16;
    public const int PlayerAttackingLeftSpriteDefaultFrameWidth = 16;
    public const int PlayerAttackingLeftSpriteDefaultTextureStartingX = 0;
    public const int PlayerAttackingLeftSpriteDefaultTextureStartingY = 0;
    public const int PlayerAttackingLeftSpriteDefaultScale = 1;
    public const float PlayerAttackingLeftSpriteDefaultLayerDepth = 0.5f;
    public const float PlayerAttackingLeftSpriteOriginX = 11f;
    public const float PlayerAttackingLeftSpriteOriginY = 0f;
    public const int PlayerAttackingLeftSpriteInitialDisplayTimeLapse = 0;
    public const int PlayerAttackingLeftSpriteInitialFrame = 0;
    public const int PlayerAttackingLeftSpriteNextFrame1 = 1;
    public const int PlayerAttackingLeftSpriteNextFrame2 = 2;
    public const int PlayerAttackingLeftSpriteNextFrame3 = 3;
    public const int PlayerAttackingLeftSpriteInitialFrameDisplayTime = 4;
    public const int PlayerAttackingLeftSpriteNextFrame1DisplayTime = 8;
    public const int PlayerAttackingLeftSpriteNextFrameDisplayTime = 1;
    //PlayerAttackingRightSprite.cs
    public const int PlayerAttackingRightSpriteDefaultFrameHeight = 16;
    public const int PlayerAttackingRightSpriteDefaultFrameWidth = 16;
    public const int PlayerAttackingRightSpriteDefaultTextureStartingX = 0;
    public const int PlayerAttackingRightSpriteDefaultTextureStartingY = 0;
    public const int PlayerAttackingRightSpriteDefaultScale = 1;
    public const float PlayerAttackingRightSpriteDefaultLayerDepth = 0.5f;
    public const int PlayerAttackingRightSpriteInitialDisplayTimeLapse = 0;
    public const int PlayerAttackingRightSpriteInitialFrame = 0;
    public const int PlayerAttackingRightSpriteNextFrame1 = 1;
    public const int PlayerAttackingRightSpriteNextFrame2 = 2;
    public const int PlayerAttackingRightSpriteNextFrame3 = 3;
    public const int PlayerAttackingRightSpriteInitialFrameDisplayTime = 4;
    public const int PlayerAttackingRightSpriteNextFrame1DisplayTime = 8;
    public const int PlayerAttackingRightSpriteNextFrameDisplayTime = 1;
    //PlayerAttackingUpSprite.cs
    public const int PlayerAttackingUpSpriteDefaultFrameHeight = 16;
    public const int PlayerAttackingUpSpriteDefaultFrameWidth = 16;
    public const int PlayerAttackingUpSpriteDefaultTextureStartingX = 0;
    public const int PlayerAttackingUpSpriteDefaultTextureStartingY = 0;
    public const int PlayerAttackingUpSpriteDefaultScale = 1;
    public const float PlayerAttackingUpSpriteDefaultLayerDepth = 0.5f;
    public const float PlayerAttackingUpSpriteOriginX = 0f;
    public const float PlayerAttackingUpSpriteOriginY = 11f;
    public const int PlayerAttackingUpSpriteInitialDisplayTimeLapse = 0;
    public const int PlayerAttackingUpSpriteInitialFrame = 0;
    public const int PlayerAttackingUpSpriteNextFrame1 = 1;
    public const int PlayerAttackingUpSpriteNextFrame2 = 2;
    public const int PlayerAttackingUpSpriteNextFrame3 = 3;
    public const int PlayerAttackingUpSpriteInitialFrameDisplayTime = 4;
    public const int PlayerAttackingUpSpriteNextFrame1DisplayTime = 8;
    public const int PlayerAttackingUpSpriteNextFrameDisplayTime = 1;
    //PlayerHoldingItemSprite.cs
    public const int PlayerHoldingItemSpriteDefaultSpriteHeight = 16;
    public const int PlayerHoldingItemSpriteDefaultSpriteWidth = 16;
    public const int PlayerHoldingItemSpriteDefaultTextureStartingX = 0;
    public const int PlayerHoldingItemSpriteDefaultTextureStartingY = 0;
    public const int PlayerHoldingItemSpriteDefaultScale = 1;
    public const float PlayerHoldingItemSpriteDefaultLayerDepth = 0.5f;
    //PlayerHoldingTriforceSprite.cs
    public const int PlayerHoldingTriforceSpriteDefaultSpriteHeight = 16;
    public const int PlayerHoldingTriforceSpriteDefaultSpriteWidth = 16;
    public const int PlayerHoldingTriforceSpriteDefaultTextureStartingX = 0;
    public const int PlayerHoldingTriforceSpriteDefaultTextureStartingY = 0;
    public const int PlayerHoldingTriforceSpriteDefaultScale = 1;
    public const float PlayerHoldingTriforceSpriteDefaultLayerDepth = 0.5f;
    //PlayerIdleDownSprite.cs
    public const int PlayerIdleDownSpriteDefaultSpriteHeight = 16;
    public const int PlayerIdleDownSpriteDefaultSpriteWidth = 16;
    public const int PlayerIdleDownSpriteDefaultTextureStartingX = 0;
    public const int PlayerIdleDownSpriteDefaultTextureStartingY = 0;
    public const int PlayerIdleDownSpriteDefaultScale = 1;
    public const float PlayerIdleDownSpriteDefaultLayerDepth = 0.5f;
    //PlayerIdleLeftSprite.cs
    public const int PlayerIdleLeftSpriteDefaultSpriteHeight = 16;
    public const int PlayerIdleLeftSpriteDefaultSpriteWidth = 16;
    public const int PlayerIdleLeftSpriteDefaultTextureStartingX = 0;
    public const int PlayerIdleLeftSpriteDefaultTextureStartingY = 0;
    public const int PlayerIdleLeftSpriteDefaultScale = 1;
    public const float PlayerIdleLeftSpriteDefaultLayerDepth = 0.5f;
    //PlayerIdleRightSprite.cs
    public const int PlayerIdleRightSpriteDefaultSpriteHeight = 16;
    public const int PlayerIdleRightSpriteDefaultSpriteWidth = 16;
    public const int PlayerIdleRightSpriteDefaultTextureStartingX = 0;
    public const int PlayerIdleRightSpriteDefaultTextureStartingY = 0;
    public const int PlayerIdleRightSpriteDefaultScale = 1;
    public const float PlayerIdleRightSpriteDefaultLayerDepth = 0.5f;
    //PlayerIdleUpSprite.cs
    public const int PlayerIdleUpSpriteDefaultSpriteHeight = 16;
    public const int PlayerIdleUpSpriteDefaultSpriteWidth = 16;
    public const int PlayerIdleUpSpriteDefaultTextureStartingX = 0;
    public const int PlayerIdleUpSpriteDefaultTextureStartingY = 0;
    public const int PlayerIdleUpSpriteDefaultScale = 1;
    public const float PlayerIdleUpSpriteDefaultLayerDepth = 0.5f;
    //PlayerInteractingDownSprite.cs
    public const int PlayerInteractingDownSpriteDefaultSpriteHeight = 16;
    public const int PlayerInteractingDownSpriteDefaultSpriteWidth = 16;
    public const int PlayerInteractingDownSpriteDefaultTextureStartingX = 0;
    public const int PlayerInteractingDownSpriteDefaultTextureStartingY = 0;
    public const int PlayerInteractingDownSpriteDefaultScale = 1;
    public const float PlayerInteractingDownSpriteDefaultLayerDepth = 0.5f;
    //PlayerInteractingLeftSprite.cs
    public const int PlayerInteractingLeftSpriteDefaultSpriteHeight = 16;
    public const int PlayerInteractingLeftSpriteDefaultSpriteWidth = 16;
    public const int PlayerInteractingLeftSpriteDefaultTextureStartingX = 0;
    public const int PlayerInteractingLeftSpriteDefaultTextureStartingY = 0;
    public const int PlayerInteractingLeftSpriteDefaultScale = 1;
    public const float PlayerInteractingLeftSpriteDefaultLayerDepth = 0.5f;
    //PlayerInteractingRightSprite.cs
    public const int PlayerInteractingRightSpriteDefaultSpriteHeight = 16;
    public const int PlayerInteractingRightSpriteDefaultSpriteWidth = 16;
    public const int PlayerInteractingRightSpriteDefaultTextureStartingX = 0;
    public const int PlayerInteractingRightSpriteDefaultTextureStartingY = 0;
    public const int PlayerInteractingRightSpriteDefaultScale = 1;
    public const float PlayerInteractingRightSpriteDefaultLayerDepth = 0.5f;
    //PlayerInteractingUpSprite.cs
    public const int PlayerInteractingUpSpriteDefaultSpriteHeight = 16;
    public const int PlayerInteractingUpSpriteDefaultSpriteWidth = 16;
    public const int PlayerInteractingUpSpriteDefaultTextureStartingX = 0;
    public const int PlayerInteractingUpSpriteDefaultTextureStartingY = 0;
    public const int PlayerInteractingUpSpriteDefaultScale = 1;
    public const float PlayerInteractingUpSpriteDefaultLayerDepth = 0.5f;
    //PlayerWalkingDownSprite.cs
    public const int PlayerWalkingDownSpriteDefaultFrameHeight = 16;
    public const int PlayerWalkingDownSpriteDefaultFrameWidth = 16;
    public const int PlayerWalkingDownSpriteDefaultTextureStartingX = 0;
    public const int PlayerWalkingDownSpriteDefaultTextureStartingY = 0;
    public const int PlayerWalkingDownSpriteDefaultScale = 1;
    public const float PlayerWalkingDownSpriteDefaultLayerDepth = 0.5f;
    public const int PlayerWalkingDownSpriteDefaultFrameDisplayTime = 6;
    //PlayerWalkingLeftSprite.cs
    public const int PlayerWalkingLeftSpriteDefaultFrameHeight = 16;
    public const int PlayerWalkingLeftSpriteDefaultFrameWidth = 16;
    public const int PlayerWalkingLeftSpriteDefaultTextureStartingX = 0;
    public const int PlayerWalkingLeftSpriteDefaultTextureStartingY = 0;
    public const int PlayerWalkingLeftSpriteDefaultScale = 1;
    public const float PlayerWalkingLeftSpriteDefaultLayerDepth = 0.5f;
    public const int PlayerWalkingLeftSpriteDefaultFrame0DisplayTime = 4;
    public const int PlayerWalkingLeftSpriteDefaultFrame1DisplayTime = 8;
    public const int PlayerWalkingLeftSpriteDefaultFrame2DisplayTime = 1;
    public const int PlayerWalkingLeftSpriteDefaultFrame3DisplayTime = 1;
    //PlayerWalkingRightSprite.cs
    public const int PlayerWalkingRightSpriteDefaultFrameHeight = 16;
    public const int PlayerWalkingRightSpriteDefaultFrameWidth = 16;
    public const int PlayerWalkingRightSpriteDefaultTextureStartingX = 0;
    public const int PlayerWalkingRightSpriteDefaultTextureStartingY = 0;
    public const int PlayerWalkingRightSpriteDefaultScale = 1;
    public const float PlayerWalkingRightSpriteDefaultLayerDepth = 0.5f;
    public const int PlayerWalkingRightSpriteDefaultFrame0DisplayTime = 4;
    public const int PlayerWalkingRightSpriteDefaultFrame1DisplayTime = 8;
    public const int PlayerWalkingRightSpriteDefaultFrame2DisplayTime = 1;
    public const int PlayerWalkingRightSpriteDefaultFrame3DisplayTime = 1;
    //PlayerWalkingUpSprite.cs
    public const int PlayerWalkingUpSpriteDefaultFrameHeight = 16;
    public const int PlayerWalkingUpSpriteDefaultFrameWidth = 16;
    public const int PlayerWalkingUpSpriteDefaultTextureStartingX = 0;
    public const int PlayerWalkingUpSpriteDefaultTextureStartingY = 0;
    public const int PlayerWalkingUpSpriteDefaultScale = 1;
    public const float PlayerWalkingUpSpriteDefaultLayerDepth = 0.5f;
    public const int PlayerWalkingUpSpriteDefaultFrame0DisplayTime = 4;
    public const int PlayerWalkingUpSpriteDefaultFrame1DisplayTime = 8;
    public const int PlayerWalkingUpSpriteDefaultFrame2DisplayTime = 1;
    public const int PlayerWalkingUpSpriteDefaultFrame3DisplayTime = 1;
    //ArrowDownProjectileSprite.cs
    public const int ArrowDownProjectileSpriteDefaultSpriteHeight = 16;
    public const int ArrowDownProjectileSpriteDefaultSpriteWidth = 16;
    public const int ArrowDownProjectileSpriteDefaultTextureStartingX = 0;
    public const int ArrowDownProjectileSpriteDefaultTextureStartingY = 0;
    public const int ArrowDownProjectileSpriteDefaultScale = 1;
    public const float ArrowDownProjectileSpriteDefaultLayerDepth = 0.5f;
    public const float ArrowDownProjectileSpriteDefaultRotation = 90f;
    //ArrowLeftProjectileSprite.cs
    public const int ArrowLeftProjectileSpriteDefaultSpriteHeight = 16;
    public const int ArrowLeftProjectileSpriteDefaultSpriteWidth = 16;
    public const int ArrowLeftProjectileSpriteDefaultTextureStartingX = 0;
    public const int ArrowLeftProjectileSpriteDefaultTextureStartingY = 0;
    public const int ArrowLeftProjectileSpriteDefaultScale = 1;
    public const float ArrowLeftProjectileSpriteDefaultLayerDepth = 0.5f;
    public const float ArrowLeftProjectileSpriteDefaultRotation = 180f;
    //ArrowProjectileHitSprite.cs
    public const int ArrowProjectileHitSpriteDefaultSpriteHeight = 16;
    public const int ArrowProjectileHitSpriteDefaultSpriteWidth = 16;
    public const int ArrowProjectileHitSpriteDefaultTextureStartingX = 0;
    public const int ArrowProjectileHitSpriteDefaultTextureStartingY = 0;
    public const int ArrowProjectileHitSpriteDefaultScale = 1;
    public const float ArrowProjectileHitSpriteDefaultLayerDepth = 0.5f;
    //ArrowRightProjectileSprite.cs
    public const int ArrowRightProjectileSpriteDefaultSpriteHeight = 16;
    public const int ArrowRightProjectileSpriteDefaultSpriteWidth = 16;
    public const int ArrowRightProjectileSpriteDefaultTextureStartingX = 0;
    public const int ArrowRightProjectileSpriteDefaultTextureStartingY = 0;
    public const int ArrowRightProjectileSpriteDefaultScale = 1;
    public const float ArrowRightProjectileSpriteDefaultLayerDepth = 0.5f;
    public const float ArrowRightProjectileSpriteDefaultRotation = 0f;
    //ArrowUpProjectileSprite.cs
    public const int ArrowUpProjectileSpriteDefaultSpriteHeight = 16;
    public const int ArrowUpProjectileSpriteDefaultSpriteWidth = 16;
    public const int ArrowUpProjectileSpriteDefaultTextureStartingX = 0;
    public const int ArrowUpProjectileSpriteDefaultTextureStartingY = 0;
    public const int ArrowUpProjectileSpriteDefaultScale = 1;
    public const float ArrowUpProjectileSpriteDefaultLayerDepth = 0.5f;
    public const float ArrowUpProjectileSpriteDefaultRotation = 270f;
    //SwordBeamDownProjectileSprite.cs
    public const int SwordBeamDownProjectileSpriteDefaultFrameHeight = 16;
    public const int SwordBeamDownProjectileSpriteDefaultFrameWidth = 16;
    public const int SwordBeamDownProjectileSpriteDefaultTextureStartingX = 0;
    public const int SwordBeamDownProjectileSpriteDefaultTextureStartingY = 0;
    public const int SwordBeamDownProjectileSpriteDefaultScale = 1;
    public const float SwordBeamDownProjectileSpriteDefaultLayerDepth = 0.5f;
    public const float SwordBeamDownProjectileSpriteDefaultRotation = 90f;
    public const int SwordBeamDownProjectileSpriteDefaultFrame0DisplayTime = 1;
    public const int SwordBeamDownProjectileSpriteDefaultFrame1DisplayTime = 1;
    public const int SwordBeamDownProjectileSpriteDefaultFrame2DisplayTime = 1;
    public const int SwordBeamDownProjectileSpriteDefaultFrame3DisplayTime = 1;
    //SwordBeamLeftProjectileSprite.cs
    public const int SwordBeamLeftProjectileSpriteDefaultFrameHeight = 16;
    public const int SwordBeamLeftProjectileSpriteDefaultFrameWidth = 16;
    public const int SwordBeamLeftProjectileSpriteDefaultTextureStartingX = 0;
    public const int SwordBeamLeftProjectileSpriteDefaultTextureStartingY = 0;
    public const int SwordBeamLeftProjectileSpriteDefaultScale = 1;
    public const float SwordBeamLeftProjectileSpriteDefaultLayerDepth = 0.5f;
    public const float SwordBeamLeftProjectileSpriteDefaultRotation = 180f;
    public const int SwordBeamLeftProjectileSpriteDefaultFrame0DisplayTime = 1;
    public const int SwordBeamLeftProjectileSpriteDefaultFrame1DisplayTime = 1;
    public const int SwordBeamLeftProjectileSpriteDefaultFrame2DisplayTime = 1;
    public const int SwordBeamLeftProjectileSpriteDefaultFrame3DisplayTime = 1;
    //SwordBeamRightProjectileSprite.cs
    public const int SwordBeamRightProjectileSpriteDefaultFrameHeight = 16;
    public const int SwordBeamRightProjectileSpriteDefaultFrameWidth = 16;
    public const int SwordBeamRightProjectileSpriteDefaultTextureStartingX = 0;
    public const int SwordBeamRightProjectileSpriteDefaultTextureStartingY = 0;
    public const int SwordBeamRightProjectileSpriteDefaultScale = 1;
    public const float SwordBeamRightProjectileSpriteDefaultLayerDepth = 0.5f;
    public const float SwordBeamRightProjectileSpriteDefaultRotation = 0f;
    public const int SwordBeamRightProjectileSpriteDefaultFrame0DisplayTime = 1;
    public const int SwordBeamRightProjectileSpriteDefaultFrame1DisplayTime = 1;
    public const int SwordBeamRightProjectileSpriteDefaultFrame2DisplayTime = 1;
    public const int SwordBeamRightProjectileSpriteDefaultFrame3DisplayTime = 1;
    //SwordBeamUpProjectileSprite.cs    
    public const int SwordBeamUpProjectileSpriteDefaultFrameHeight = 16;
    public const int SwordBeamUpProjectileSpriteDefaultFrameWidth = 16;
    public const int SwordBeamUpProjectileSpriteDefaultTextureStartingX = 0;
    public const int SwordBeamUpProjectileSpriteDefaultTextureStartingY = 0;
    public const int SwordBeamUpProjectileSpriteDefaultScale = 1;
    public const float SwordBeamUpProjectileSpriteDefaultLayerDepth = 0.5f;
    public const float SwordBeamUpProjectileSpriteDefaultRotation = 270f;
    public const int SwordBeamUpProjectileSpriteDefaultFrame0DisplayTime = 1;
    public const int SwordBeamUpProjectileSpriteDefaultFrame1DisplayTime = 1;
    public const int SwordBeamUpProjectileSpriteDefaultFrame2DisplayTime = 1;
    public const int SwordBeamUpProjectileSpriteDefaultFrame3DisplayTime = 1;
    //BombExplosionSprite.cs
    public const int BombExplodingSpriteDefaultFrameHeight = 16;
    public const int BombExplodingSpriteDefaultFrameWidth = 16;
    public const int BombExplodingSpriteDefaultTextureStartingX = 0;
    public const int BombExplodingSpriteDefaultTextureStartingY = 0;
    public const int BombExplodingSpriteDefaultScale = 1;
    public const float BombExplodingSpriteDefaultLayerDepth = 0.5f;
    public const int BombExplodingSpriteDefaultFrame0DisplayTime = 1;
    public const int BombExplodingSpriteDefaultFrame1DisplayTime = 8;
    public const int BombExplodingSpriteDefaultFrame2DisplayTime = 4;
    public const int BombExplodingSpriteDefaultFrame3DisplayTime = 2;
    //BombSprite.cs
    public const int BombSpriteDefaultSpriteHeight = 16;
    public const int BombSpriteDefaultSpriteWidth = 16;
    public const int BombSpriteDefaultTextureStartingX = 0;
    public const int BombSpriteDefaultTextureStartingY = 0;
    public const int BombSpriteDefaultScale = 1;
    public const float BombSpriteDefaultLayerDepth = 0.5f;
    //WodenBoomerangSprite.cs
    public const int WoodenBoomerangSpriteDefaultFrameHeight = 16;
    public const int WoodenBoomerangSpriteDefaultFrameWidth = 16;
    public const int WoodenBoomerangSpriteDefaultTextureStartingX = 0;
    public const int WoodenBoomerangSpriteDefaultTextureStartingY = 0;
    public const int WoodenBoomerangSpriteDefaultScale = 1;
    public const float WoodenBoomerangSpriteDefaultLayerDepth = 0.5f;
    public const int WoodenBoomerangSpriteDefaultFrameDisplayTime = 2;
    //EmptyRoomSprite.cs
    public const int EmptyRoomSpriteDefaultSpriteHeight = 0;
    public const int EmptyRoomSpriteDefaultSpriteWidth = 0;
    public const int EmptyRoomSpriteDefaultTextureStartingX = 0;
    public const int EmptyRoomSpriteDefaultTextureStartingY = 0;
    public const int EmptyRoomSpriteDefaultScale = 1;
    public const float EmptyRoomSpriteDefaultLayerDepth = 1.0f;
    public const float EmptyRoomSpriteDefaultOriginX = 0f;
    public const float EmptyRoomSpriteDefaultOriginY = 0f;
    public const float EmptyRoomSpriteDefaultRotation = 0f;
    //RoomInnerBorderSprite.cs
    public const int RoomInnerBorderSpriteDefaultSpriteHeight = 176;
    public const int RoomInnerBorderSpriteDefaultSpriteWidth = 256;
    public const int RoomInnerBorderSpriteDefaultTextureStartingX = 0;
    public const int RoomInnerBorderSpriteDefaultTextureStartingY = 0;
    public const int RoomInnerBorderSpriteDefaultScale = 1;
    public const float RoomInnerBorderSpriteDefaultLayerDepth = 0.5f;
    public const float RoomInnerBorderSpriteDefaultOriginX = 0f;
    public const float RoomInnerBorderSpriteDefaultOriginY = 0f;
    public const float RoomInnerBorderSpriteDefaultRotation = 0f;
    //RoomDungeonTilesSprite.cs
    public const int RoomDungeonTilesSpriteDefaultSpriteHeight = 176;
    public const int RoomDungeonTilesSpriteDefaultSpriteWidth = 256;
    public const int RoomDungeonTilesSpriteDefaultTextureStartingX = 0;
    public const int RoomDungeonTilesSpriteDefaultTextureStartingY = 0;
    public const int RoomDungeonTilesSpriteDefaultScale = 1;
    public const float RoomDungeonTilesSpriteDefaultLayerDepth = 0.5f;
    public const float RoomDungeonTilesSpriteDefaultOriginX = 0f;
    public const float RoomDungeonTilesSpriteDefaultOriginY = 0f;
    public const float RoomDungeonTilesSpriteDefaultRotation = 0f;
    //RoomOuterBorderSprite.cs
    public const int RoomOuterBorderSpriteDefaultSpriteHeight = 176;
    public const int RoomOuterBorderSpriteDefaultSpriteWidth = 256;
    public const int RoomOuterBorderSpriteDefaultTextureStartingX = 0;
    public const int RoomOuterBorderSpriteDefaultTextureStartingY = 0;
    public const int RoomOuterBorderSpriteDefaultScale = 1;
    public const float RoomOuterBorderSpriteDefaultLayerDepth = 0.5f;
    public const float RoomOuterBorderSpriteDefaultOriginX = 0f;
    public const float RoomOuterBorderSpriteDefaultOriginY = 0f;
    public const float RoomOuterBorderSpriteDefaultRotation = 0f;
    //UndergroundRoomSprite.cs
    public const int UndergroundRoomSpriteDefaultSpriteHeight = 176;
    public const int UndergroundRoomSpriteDefaultSpriteWidth = 256;
    public const int UndergroundRoomSpriteDefaultTextureStartingX = 0;
    public const int UndergroundRoomSpriteDefaultTextureStartingY = 0;
    public const int UndergroundRoomSpriteDefaultScale = 1;
    public const float UndergroundRoomSpriteDefaultLayerDepth = 0.5f;
    public const float UndergroundRoomSpriteDefaultOriginX = 0f;
    public const float UndergroundRoomSpriteDefaultOriginY = 0f;
    public const float UndergroundRoomSpriteDefaultRotation = 0f;
    //BlockSpriteFactory.cs
    public const int BlueFloorSpriteTextureStartingY = 0;
    public const int SquareBlockSpriteTextureStartingY = 16;
    public const int StatueOneEntranceSpriteTextureStartingY = 32;
    public const int StatueTwoEntranceSpriteTextureStartingY = 48;
    public const int StatueOneEndSpriteTextureStartingY = 64;
    public const int StatueTwoEndSpriteTextureStartingY = 80;
    public const int BlackSquareSpriteTextureStartingY = 96;
    public const int BlueSandSpriteTextureStartingY = 112;
    public const int BlueGapSpriteTextureStartingY = 128;
    public const int StairsSpriteTextureStartingY = 144;
    public const int WhiteBrickSpriteTextureStartingY = 160;
    public const int WhiteLadderSpriteTextureStartingY = 176;
    //DoorSpriteFactory.cs
    public const int DoorSpriteTextureStartingY = 704;
    public const int DoorSpriteTextureStep = 32;
    public const int DoorSpriteTextureHalfStep = 16;
    //SpriteFactory
    public const int StandardSpriteRows = 1;
    public const int StandardSpriteColumns = 1;
    public const int StandardSpriteFrames = 1;
    public const float MinLayerDepth = 0.0f;
    public const float MaxLayerDepth = 1.0f;
    //EnemySpriteFactory.cs
    public const int KeeseSpriteColumns = 2;
    public const int KeeseSpriteFrames = 2;
    public const int KeeseLandedSpriteTextureStartingX = 16;
    public const int StalfosSpriteTextureStartingY = 16;
    public const int GelSpriteColumns = 2;
    public const int GelSpriteFrames = 2;
    public const int GelSpriteTextureStartingY = 32;
    public const int WallMasterSpriteColumns = 2;
    public const int WallMasterSpriteFrames = 2;
    public const int WallMasterSpriteTextureStartingY = 96;
    public const int OldManSpriteTextureStartingX = 0;
    public const int OldManSpriteTextureStartingY = 112;
    public const int SpikeCrossSpriteTextureStartingY = 128;
    public const int AquamentusSpriteColumns = 2;
    public const int AquamentusSpriteFrameHeight = 32;
    public const int AquamentusSpriteFrameWidth = 24;
    public const int AquamentusSpriteFrames = 2;
    public const int AquamentusSpriteTextureStartingY = 144;
    public const int AquamentusAttackingSpriteTextureStartingX = 48;
    public const int AquamentusAttackSpriteColumns = 4;
    public const int AquamentusAttackSpriteFrames = 4;
    public const int AquamentusAttackSpriteTextureStartingY = 64;
    public const int GoriyaWalkingSpriteColumns = 2;
    public const int GoriyaWalkingSpriteFrames = 2;
    public const int GoriyaWalkingUpSpriteTextureStartingY = 64;
    public const int GoriyaWalkingDownSpriteTextureStartingY = 48;
    public const int GoriyaWalkingLeftSpriteTextureStartingY = 80;
    public const int GoriyaWalkingRightSpriteTextureStartingY = 80;
    //ItemSpriteFactory.cs
    public const int HeartItemSpriteColumns = 2;
    public const int HeartItemSpriteFrames = 2;
    public const int HeartContainerItemSpriteTextureStartingY = 16;
    public const int ClockItemSpriteTextureStartingY = 32;
    public const int FiveRupeesItemSpriteTextureStartingY = 48;
    public const int RupeeItemSpriteColumns = 2;
    public const int RupeeItemSpriteFrames = 2;
    public const int RupeeItemSpriteTextureStartingY = 48;
    public const int MapItemSpriteTextureStartingY = 64;
    public const int WoodenBoomerangItemSpriteTextureStartingY = 80;
    public const int BombItemSpriteTextureStartingY = 96;
    public const int BowItemSpriteTextureStartingY = 112;
    public const int ArrowItemSpriteTextureStartingY = 128;
    public const int KeyItemSpriteTextureStartingY = 144;
    public const int CompassItemSpriteTextureStartingY = 160;
    public const int TriforcePieceItemSpriteColumns = 2;
    public const int TriforcePieceItemSpriteFrames = 2;
    public const int TriforcePieceItemSpriteTextureStartingY = 176;
    public const int FairyItemSpriteColumns = 2;
    public const int FairyItemSpriteFrames = 2;
    public const int FairyItemSpriteTextureStartingY = 192;
    public const int FireSpriteTextureStartingY = 208;
    //ParticleSpriteFactory.cs
    public const int DeathParticleSpriteColumns = 2;
    public const int DeathParticleSpriteFrames = 2;
    public const int DeathParticleSpriteFrameHeight = 16;
    public const int DeathParticleSpriteFrameWidth = 16;
    public const int SwordBeamParticleSpriteColumns = 4;
    public const int SwordBeamParticleSpriteFrames = 4;
    public const int SwordBeamParticleSpriteTextureStartingY = 18;
    public const int SwordBeamParticleSpriteFrameHeight = 10;
    public const int SwordBeamParticleSpriteFrameWidth = 8;
    public const int SpawnParticleSpriteColumns = 3;
    public const int SpawnParticleSpriteFrames = 3;
    public const int SpawnParticleSpriteTextureStartingY = 32;
    public const int SpawnParticleSpriteFrameHeight = 16;
    public const int SpawnParticleSpriteFrameWidth = 16;
    //PlayerSpriteFactory.cs
    public const int PlayerAttackingSpriteColumns = 4;
    public const int PlayerAttackingSpriteFrames = 4;
    public const int PlayerAttackingSpriteFrameWidth = 16;
    public const int PlayerAttackingRightSpriteFrameWidth = 27;
    public const int PlayerAttackingLeftSpriteFrameWidth = 27;
    public const int PlayerAttackingDownSpriteFrameHeight = 27;
    public const int PlayerAttackingUpSpriteFrameHeight = 27;
    public const int PlayerAttackingRightSpriteFrameHeight = 16;
    public const int PlayerAttackingLeftSpriteFrameHeight = 16;
    public const int PlayerAttackingDownSpriteTextureStartingY = 48;
    public const int PlayerAttackingUpSpriteTextureStartingY = 84;
    public const int PlayerAttackingRightSpriteTextureStartingY = 112;
    public const int PlayerAttackingLeftSpriteTextureStartingY = 112;
    public const int PlayerWalkingSpriteColumns = 4;
    public const int PlayerWalkingSpriteFrames = 2;
    public const int PlayerWalkingDownSpriteTextureStartingY = 0;
    public const int PlayerWalkingUpSpriteTextureStartingY = 16;
    public const int PlayerWalkingLeftSpriteTextureStartingY = 32;
    public const int PlayerWalkingRightSpriteTextureStartingY = 32;
    public const int PlayerHoldingItemSpriteTextureStartingY = 128;
    public const int PlayerHoldingTriforceSpriteTextureStartingY = 144;
    public const int PlayerInteractingDownSpriteTextureStartingY = 48;
    public const int PlayerInteractingUpSpriteTextureStartingY = 96;
    public const int PlayerInteractingLeftSpriteTextureStartingY = 112;
    public const int PlayerInteractingRightSpriteTextureStartingY = 112;
    public const int PlayerIdleDownSpriteTextureStartingY = 0;
    public const int PlayerIdleUpSpriteTextureStartingY = 16;
    public const int PlayerIdleLeftSpriteTextureStartingY = 32;
    public const int PlayerIdleRightSpriteTextureStartingY = 32;
    //ProjectileSpriteFactory.cs
    public const int ArrowProjectileHitSpriteTextureStartingX = 16;
    public const int SwordBeamProjectileSpriteColumns = 4;
    public const int SwordBeamProjectileSpriteFrames = 4;
    public const int SwordBeamProjectileSpriteTextureStartingY = 48;
    public const int WoodenBoomerangSpriteColumns = 3;
    public const int WoodenBoomerangSpriteFrames = 3;
    public const int WoodenBoomerangSpriteTextureStartingY = 16;
    public const int BombExplodingSpriteColumns = 4;
    public const int BombExplodingSpriteFrames = 4;
    public const int BombExplodingSpriteTextureStartingY = 32;
    public const int BombSpriteTextureStartingY = 32;
    //RoomSpriteFactory.cs
    public const int UndergroundRoomSpriteTextureStartingY = 0;
    public const int RoomOuterBorderSpriteTextureStartingY = 176;
    public const int RoomInnerBorderSpriteTextureStartingY = 352;
    public const int RoomDungeonTilesSpriteTextureStartingY = 528;
    public const int EmptyRoomSpriteTextureStartingY = 0;
    //TextSprite.cs
    public const float TextSpriteInitialLayerDepth = 0.5f;
    public const int TextSpriteInitialXPosition = 0;
    public const int TextSpriteInitialYPosition = 0;
}}