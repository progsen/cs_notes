 
        public Gamepad gamepad;
        public Controller controller;
        internal Vibration vibration = new Vibration();
		
            //setting up controller
            gc.controller = new Controller(UserIndex.One);
            gc.vibrationLeftMotorSpeed = CONTROLLER_RUMBLE;
            gc.vibration.RightMotorSpeed = (ushort)gc.vibrationLeftMotorSpeed;
            gc.vibration.LeftMotorSpeed = (ushort)gc.vibrationLeftMotorSpeed;
			
			
			
		private void UpdateControllerInput(){
            gamepad = gc.controller.GetState().Gamepad;
            if (gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight) && lastKeyPressRight == false)
            {
                MovePlayer1(1, 0);
                lastKeyPressRight = true;
            }
            else
            {
                lastKeyPressRight = gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight);
            }
            if (gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft) && lastKeyPressLeft == false)
            {
                MovePlayer1(-1, 0);
                lastKeyPressLeft = true;
            }
            else
            {
                lastKeyPressLeft = gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft);
            }
            if (gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp) && lastKeyPressUp == false)
            {
                MovePlayer1(0, -1);
                lastKeyPressUp = true;
            }
            else
            {
                lastKeyPressUp = gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp);
            }
            if (gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown) && lastKeyPressDown == false)
            {
                MovePlayer1(0, 1);
                lastKeyPressDown = true;
            }
            else
            {
                lastKeyPressDown = gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown);
            }
            if (gamepad.Buttons.HasFlag(GamepadButtonFlags.A) && lastAButton == false)
            {
                if (gc.p2BombCount >= 1)
                {
                    gc.SetControllerVibration(CONTROLLER_RUMBLE);
                   
                    gc.p2BombCount--;
                    new Bomb(gc, 2500, p1Pos, false);
                    lastAButton = true;
                }
            }
            else
            {
                lastAButton = gamepad.Buttons.HasFlag(GamepadButtonFlags.A);
            }
            if (gamepad.Buttons.HasFlag(GamepadButtonFlags.B) && lastBButton == false)
            {
                if (gc.p2BombCount >= 1)
                {
                    gc.SetControllerVibration(CONTROLLER_RUMBLE);

                    gc.p2BombCount--;
                    new Bomb(gc, 2500, p1Pos, false);
                    lastBButton = true;
                }
            }
            else
            {
                lastBButton = gamepad.Buttons.HasFlag(GamepadButtonFlags.B);
            }
            if (gamepad.Buttons.HasFlag(GamepadButtonFlags.X) && lastXButton == false)
            {
                if (gc.p2BombCount >= 1)
                {
                    gc.SetControllerVibration(CONTROLLER_RUMBLE);

                    gc.p2BombCount--;
                    new Bomb(gc, 2500, p1Pos, false);
                    lastXButton = true;
                }
            }
            else
            {
                lastXButton = gamepad.Buttons.HasFlag(GamepadButtonFlags.X);
            }
            if (gamepad.Buttons.HasFlag(GamepadButtonFlags.Y) && lastYButton == false)
            {
                if (gc.p2BombCount >= 1)
                {
                    gc.SetControllerVibration(CONTROLLER_RUMBLE);

                    gc.p2BombCount--;
                    new Bomb(gc, 2500, p1Pos, false);
                    lastYButton = true;
                }
            }
            else
            {
                lastYButton = gamepad.Buttons.HasFlag(GamepadButtonFlags.Y);
            }
            if (gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb) && lastRightThumb == false)
            {
                if (gc.p2freezeCount > 0 && canMoveP1)
                {
                    gc.p2freezeCount--;
                    new Freeze(gc, this, true);
                }
                lastRightThumb = true;
            }
            else
            {
                lastRightThumb = gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb);
            }
        }
		
		internal void SetControllerVibration(int speed)
        {
            if (!controllerMode || !controller.IsConnected) return;
            vibrationLeftMotorSpeed = speed;
            vibration.LeftMotorSpeed = (ushort)vibrationLeftMotorSpeed;
            vibration.RightMotorSpeed = (ushort)vibrationLeftMotorSpeed;
            controller.SetVibration(vibration);
        }
		
		
		