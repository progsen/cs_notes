 private Graphics InitGraphics(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //make nice pixels
            g.SmoothingMode = SmoothingMode.None;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;


            g.Transform = new Matrix();
            float roomw = context.room.tiles[0].Length * context.tileSize;
            float roomh = context.room.tiles.Length * context.tileSize;
            roomw /= 2;
            roomh /= 2;
            roomw *= context.scaleunit;
            roomh *= context.scaleunit;
            float px = context.player.rectangle.X* context.scaleunit;
            float py = context.player.rectangle.Y * context.scaleunit;

            float screenscale = GetWindowsScaling();
            e.Graphics.TranslateTransform(-px+roomw, -py+roomh);
          g.ScaleTransform(context.scaleunit, context.scaleunit);

            //there will be some tearing between tiles, a solution to that is to render to a bitmap then draw that bitmap, fun challenge?
            g.Clear(Color.Black);
            return g;
        }