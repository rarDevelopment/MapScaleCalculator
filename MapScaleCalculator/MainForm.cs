using MapScaleCalculator.Model;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Windows.Forms.VisualStyles;
using SkiaSharp;
using System.IO;

namespace MapScaleCalculator
{
    public partial class MainForm : Form
    {
        
        private string _imagePath = "C:\\temp\\map_en.png";
        private string _markData = /*lang=json*/ "[\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.GasStation.03\",\r\n    \"Name\": \"BURD To Go\",\r\n    \"Location\": { \"X\": -8568, \"Y\": -17134, \"Z\": 2686 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.14\",\r\n    \"Name\": \"Kite\\u0027s Flight\",\r\n    \"Location\": { \"X\": 107605, \"Y\": 89675, \"Z\": 1115 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.20\",\r\n    \"Name\": \"Splitting Pins\",\r\n    \"Location\": { \"X\": -44328, \"Y\": 102776, \"Z\": 3997 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.POI.Generic.17\",\r\n    \"Name\": \"BRUTAL BOXCARS\",\r\n    \"Location\": { \"X\": 9691, \"Y\": -34932, \"Z\": 4432 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.POI.Generic.18\",\r\n    \"Name\": \"MASKED MEADOWS\",\r\n    \"Location\": { \"X\": 15134, \"Y\": 76343, \"Z\": 3598 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.POI.Generic.04\",\r\n    \"Name\": \"CANYON CROSSING\",\r\n    \"Location\": { \"X\": -57184, \"Y\": 71601, \"Z\": 4432 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.10\",\r\n    \"Name\": \"Yacht Stop\",\r\n    \"Location\": { \"X\": 6469, \"Y\": -110943, \"Z\": -812 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.32\",\r\n    \"Name\": \"Way Station\",\r\n    \"Location\": { \"X\": 39927, \"Y\": 88133, \"Z\": 3115 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.POI.Generic.08\",\r\n    \"Name\": \"WHIFFY WHARF\",\r\n    \"Location\": { \"X\": -88950, \"Y\": -84496, \"Z\": 4432 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.POI.Generic.10\",\r\n    \"Name\": \"PUMPED POWER\",\r\n    \"Location\": { \"X\": 50225, \"Y\": -57403, \"Z\": 4432 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.11\",\r\n    \"Name\": \"Moisty Manor\",\r\n    \"Location\": { \"X\": -64686, \"Y\": -72055, \"Z\": 5784 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.GasStation.01\",\r\n    \"Name\": \"BURD To Go\",\r\n    \"Location\": { \"X\": 36796, \"Y\": 50951, \"Z\": 3115 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.POI.Generic.12\",\r\n    \"Name\": \"TWINKLE TERRACE\",\r\n    \"Location\": { \"X\": -83173, \"Y\": -26970, \"Z\": 4432 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.24\",\r\n    \"Name\": \"Pumpin\\u0027 Pipes\",\r\n    \"Location\": { \"X\": 99637, \"Y\": -34983, \"Z\": -812 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.02\",\r\n    \"Name\": \"Battle\\u0027s End\",\r\n    \"Location\": { \"X\": -66619.59, \"Y\": 12582.449, \"Z\": -812 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.POI.Generic.01\",\r\n    \"Name\": \"DEMON\\u0027S DOJO\",\r\n    \"Location\": { \"X\": 89381, \"Y\": -66288, \"Z\": 4432 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.27\",\r\n    \"Name\": \"All You Can Catch!\",\r\n    \"Location\": { \"X\": -40015, \"Y\": -6505, \"Z\": 2695 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.29\",\r\n    \"Name\": \"Boulder Gorge\",\r\n    \"Location\": { \"X\": 85218, \"Y\": 79389, \"Z\": 813 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.37\",\r\n    \"Name\": \"Sakura Plunge\",\r\n    \"Location\": { \"X\": -70208.7, \"Y\": -11012.834, \"Z\": 3284 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.17\",\r\n    \"Name\": \"Overlook Lighthouse\",\r\n    \"Location\": { \"X\": 108866.43, \"Y\": -3254.999, \"Z\": 5784 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.GasStation.05\",\r\n    \"Name\": \"BURD To Go\",\r\n    \"Location\": { \"X\": 82367, \"Y\": -13166, \"Z\": 3079 }\r\n  },\r\n  { \"Id\": \"Athena.Location.POI.Generic.11\", \"Name\": \"SHINING SPAN\", \"Location\": { \"X\": 89518, \"Y\": 8637, \"Z\": 2432 } },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.04\",\r\n    \"Name\": \"Big Bend\",\r\n    \"Location\": { \"X\": -18661, \"Y\": 83440, \"Z\": 5507 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.04\",\r\n    \"Name\": \"Big Bend\",\r\n    \"Location\": { \"X\": -34980, \"Y\": 66821, \"Z\": 5507 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.03\",\r\n    \"Name\": \"Y\\u014Dkina Boardwalk\",\r\n    \"Location\": { \"X\": -112977, \"Y\": 27192, \"Z\": 5784 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.POI.Generic.05\",\r\n    \"Name\": \"WARRIOR\\u0027S WATCH\",\r\n    \"Location\": { \"X\": -49672, \"Y\": 27494, \"Z\": 4432 }\r\n  },\r\n  { \r\n    \"Id\": \"Athena.Location.POI.Generic.13\", \r\n    \"Name\": \"BURD\", \r\n    \"Location\": { \"X\": -90402, \"Y\": 41655, \"Z\": 4432 } },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.26\",\r\n    \"Name\": \"Dashi Dash\",\r\n    \"Location\": { \"X\": 83752, \"Y\": 39229, \"Z\": 3115 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.30\",\r\n    \"Name\": \"Sakura Stadium\",\r\n    \"Location\": { \"X\": -114385, \"Y\": -10804, \"Z\": 5784 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.31\",\r\n    \"Name\": \"Base Tunnel\",\r\n    \"Location\": { \"X\": 39245, \"Y\": -21040, \"Z\": 2634 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.16\",\r\n    \"Name\": \"Cliffside Lighthouse\",\r\n    \"Location\": { \"X\": -88040.836, \"Y\": -108498.84, \"Z\": 5784 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.28\",\r\n    \"Name\": \"Placid Paddies\",\r\n    \"Location\": { \"X\": -55965.082, \"Y\": -102581.57, \"Z\": 5784 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.POI.Generic.09\",\r\n    \"Name\": \"FLOODED FROGS\",\r\n    \"Location\": { \"X\": -22754, \"Y\": -89761, \"Z\": 4432 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.34\",\r\n    \"Name\": \"Fightin\\u0027 Frogs\",\r\n    \"Location\": { \"X\": -31402.084, \"Y\": -113688.57, \"Z\": 5784 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.POI.Generic.14\",\r\n    \"Name\": \"NIGHTSHIFT FOREST\",\r\n    \"Location\": { \"X\": -82555, \"Y\": 7074, \"Z\": 4432 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.31\",\r\n    \"Name\": \"Base Tunnel\",\r\n    \"Location\": { \"X\": 39243, \"Y\": -32793, \"Z\": 2634 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.POI.Generic.16\",\r\n    \"Name\": \"HOPEFUL HEIGHTS\",\r\n    \"Location\": { \"X\": 63888, \"Y\": 89955, \"Z\": 2432 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.21\",\r\n    \"Name\": \"Crabby Cove\",\r\n    \"Location\": { \"X\": 48494, \"Y\": 116789, \"Z\": -424 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.POI.Generic.07\",\r\n    \"Name\": \"FOXY FLOODGATE\",\r\n    \"Location\": { \"X\": -7058, \"Y\": 14150, \"Z\": 4432 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.22\",\r\n    \"Name\": \"Kappa Kappa Farm\",\r\n    \"Location\": { \"X\": 97349, \"Y\": 61602, \"Z\": 813 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.GasStation.02\",\r\n    \"Name\": \"BURD To Go\",\r\n    \"Location\": { \"X\": -75809, \"Y\": -52624, \"Z\": 1998 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.01\",\r\n    \"Name\": \"Spiral Shoots\",\r\n    \"Location\": { \"X\": 6966, \"Y\": 104399, \"Z\": 4350 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.05\",\r\n    \"Name\": \"Sleepwalker\\u0027s Peril\",\r\n    \"Location\": { \"X\": -50443, \"Y\": -72796, \"Z\": 5784 }\r\n  },\r\n  { \"Id\": \"Athena.Location.POI.Generic.06\", \"Name\": \"SEAPORT CITY\", \"Location\": { \"X\": 56067, \"Y\": 18084, \"Z\": 4432 } },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.GasStation.04\",\r\n    \"Name\": \"BURD To Go\",\r\n    \"Location\": { \"X\": 50399, \"Y\": -84844, \"Z\": 2686 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.12\",\r\n    \"Name\": \"Rolling Blossoms Farm\",\r\n    \"Location\": { \"X\": 54652, \"Y\": 56231, \"Z\": 2479 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.36\",\r\n    \"Name\": \"Rocky RVs\",\r\n    \"Location\": { \"X\": -11103, \"Y\": -63688, \"Z\": 5784 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.15\",\r\n    \"Name\": \"Crimson Lighthouse\",\r\n    \"Location\": { \"X\": -106491, \"Y\": 109544, \"Z\": 5784 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.06\",\r\n    \"Name\": \"Lovely Lane\",\r\n    \"Location\": { \"X\": -98848, \"Y\": -63140, \"Z\": 5784 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.18\",\r\n    \"Name\": \"Lily Lake\",\r\n    \"Location\": { \"X\": -28424, \"Y\": -67623, \"Z\": 5784 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.POI.Generic.03\",\r\n    \"Name\": \"SHOGUN\\u0027S SOLITUDE\",\r\n    \"Location\": { \"X\": -88773, \"Y\": 94154, \"Z\": 4432 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.35\",\r\n    \"Name\": \"Martial Maneuvers\",\r\n    \"Location\": { \"X\": 39226, \"Y\": -103508, \"Z\": -812 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.13\",\r\n    \"Name\": \"Open-Air Onsen\",\r\n    \"Location\": { \"X\": 73774, \"Y\": -29538, \"Z\": -812 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.UnNamedPOI.Landmark.08\",\r\n    \"Name\": \"Salty Docks\",\r\n    \"Location\": { \"X\": 115422, \"Y\": 40600, \"Z\": 813 }\r\n  },\r\n  {\r\n    \"Id\": \"Athena.Location.POI.Generic.02\",\r\n    \"Name\": \"MAGIC MOSSES\",\r\n    \"Location\": { \"X\": 13376, \"Y\": -72450, \"Z\": 4432 }\r\n  },\r\n  { \r\n    \"Id\": \"Athena.Location.POI.Generic.15\", \r\n    \"Name\": \"LOST LAKE\", \r\n    \"Location\": { \"X\": -29552, \"Y\": -42878, \"Z\": 4432 } \r\n  }\r\n]";

        private Mark[]? _marks;
        private Point _topLeftHandle, _bottomRightHandle;
        private TextBox txtScale;
        private GrabLocation _holding = GrabLocation.None;
        private SizeF _mapSize;
        private Image _image;

        PointF _offsets, _scale;
        private Label lblScale;
        private Label lblOffset;
        private TextBox txtOffset;
        private Button btnGenerate;
        private PictureBox pbMap;
        
        // We are going to view points in three ways:
        //    Mark Point: The coordinates in the mark data, which ranges from roughly -30000 to +30000
        //    Map Point: The coordinates on the map image, which ranges from roughly 0 to 2000 - the size of the image
        //    Screen Point: The coordinates on the PictureBox in which the image is placed. The image is scaled to fit, and centered in the box. So we have to offset
        //      to where the image is and scale for how much the image is shrunk or grown. (Honestly, I never tested what happens if you have a smaller image than your screen)
        public MainForm()
        {
            InitializeComponent();

            _image = System.Drawing.Image.FromFile(_imagePath);
            _mapSize = _image.Size;

            pbMap.Image = _image;
            pbMap.SizeMode = PictureBoxSizeMode.Zoom;

            _marks = System.Text.Json.JsonSerializer.Deserialize<Mark[]>(_markData);
            
            _topLeftHandle = new Point(0 ,0);
            _bottomRightHandle = (Point)_image.Size;

            (_scale, _offsets) = CalculateScaleAndOFfset(_marks, new PointF(0, 0), (PointF)(SizeF)_mapSize);
        }

        // We want to calculate what the scaling is between Mark Points and Map Points. We know how much range there is between the smallest and largest points in the Mark Points.
        // We know how wide the image is. The scale is simply the target (2000ish, changed by where we drag the box) divided by the Mark range (the 60000ish the marks have)
        // The formula we will be using for translating points is X_new = (X_old * scale) + offset.
        // We know an X_old and X_new (the top/leftmost point of the drag box, and the top/leftmost marks). We know the scale. So we simly rearrange and plug in values.
        // offset = x_new - (x_old * scale) 
        //
        // When doing all of these calculations we assume the scale and offsets for X and Y can be different (they can), so we work with scale and offset as Points, so we have a value for X and Y.
        // The code that will eventually use this only uses one value for scale, which won't matter *too* much because the scale is pretty close.
        // Also worth noting, rather than use any "mark" on the map, we actually are basically using the "drag" handle in the top left and bottom right for these calculations.
        private (PointF, PointF) CalculateScaleAndOFfset(Mark[] marks, PointF targetTopLeft, PointF targetBottomRight)
        {
            var actualLeftmost = _marks.Select(m => m.Location.X).Min();
            var actualTopMost = _marks.Select(m => m.Location.Y).Min();

            var actualRightMost = _marks.Select(m => m.Location.X).Max();
            var actualBottomMost = _marks.Select(m => m.Location.Y).Max();
            var scale = new PointF(
                    (targetBottomRight.X - targetTopLeft.X) / (actualRightMost - actualLeftmost),
                    (targetBottomRight.Y - targetTopLeft.Y) / (actualBottomMost - actualTopMost));
            
            var offset = new PointF(
                targetTopLeft.X - actualLeftmost * scale.X,
                targetTopLeft.Y - actualTopMost * scale.Y
                );

            txtScale.Text = scale.ToString();
            txtOffset.Text = offset.ToString();

            return (scale, offset);
        }

        private void InitializeComponent()
        {
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.txtScale = new System.Windows.Forms.TextBox();
            this.lblScale = new System.Windows.Forms.Label();
            this.lblOffset = new System.Windows.Forms.Label();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMap
            // 
            this.pbMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMap.Location = new System.Drawing.Point(3, 6);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(1045, 500);
            this.pbMap.TabIndex = 0;
            this.pbMap.TabStop = false;
            this.pbMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMap_Paint);
            this.pbMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseDown);
            this.pbMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseMove);
            this.pbMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseUp);
            // 
            // txtScale
            // 
            this.txtScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtScale.Location = new System.Drawing.Point(55, 515);
            this.txtScale.Name = "txtScale";
            this.txtScale.ReadOnly = true;
            this.txtScale.Size = new System.Drawing.Size(300, 23);
            this.txtScale.TabIndex = 2;
            // 
            // lblScale
            // 
            this.lblScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblScale.AutoSize = true;
            this.lblScale.Location = new System.Drawing.Point(12, 515);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(37, 15);
            this.lblScale.TabIndex = 3;
            this.lblScale.Text = "Scale:";
            // 
            // lblOffset
            // 
            this.lblOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOffset.AutoSize = true;
            this.lblOffset.Location = new System.Drawing.Point(395, 515);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(42, 15);
            this.lblOffset.TabIndex = 4;
            this.lblOffset.Text = "Offset:";
            // 
            // txtOffset
            // 
            this.txtOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOffset.Location = new System.Drawing.Point(443, 515);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.ReadOnly = true;
            this.txtOffset.Size = new System.Drawing.Size(300, 23);
            this.txtOffset.TabIndex = 5;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(993, 519);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Download";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1074, 544);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtOffset);
            this.Controls.Add(this.lblOffset);
            this.Controls.Add(this.lblScale);
            this.Controls.Add(this.txtScale);
            this.Controls.Add(this.pbMap);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // This is the conversion which is also going to be used in the code which puts the X on the map
        private PointF ConvertMarkPointToMapPoint(PointF p, PointF scale, PointF offsets)
        {
            // Apply scale and offsets
            return new PointF(
                p.X * scale.X + offsets.X,
                p.Y * scale.Y + offsets.Y
                );
        }

        // Basically doing what the PictureBox class does, since it doesn't make available the location the map was actually drawn, or how big it actually got drawn
        // Used for knowing where to draw the points on the PictureBox, given that we know the location to draw on the map
        private Point ConvertMapPointToDisplayPoint(PointF p, PictureBox pb)
        {
            var pbSize = pb.Size;

            // Whichever direction has the most trouble fitting, the image will be scaled that much
            var backgroundImageScale = Math.Min(pbSize.Width / _mapSize.Width, pbSize.Height / _mapSize.Height);

            var imageScaledSize = _mapSize * backgroundImageScale;

            // This is also a point, which will result in a par of offsets, one of which should always be 0
            var backgroundOffset = ((pbSize - imageScaledSize) /2);

            // Apply scale and offsets to the given point. All of the above values could have been calculated on any resize and stored instead of being recalculated.
            return 
                new Point(
                (int)(p.X * backgroundImageScale + backgroundOffset.Width),
                (int)(p.Y * backgroundImageScale + backgroundOffset.Height));
        }

        // This is the opposite of the above method, used when a click is received or the mouse is hovered, to know if we are on the drag corners.
        private Point ConvertDisplayPointToMapPoint(PointF p, PictureBox pb)
        {
            var pbSize = pb.Size;

            var backgroundImageScale = Math.Min(pbSize.Width / _mapSize.Width, pbSize.Height / _mapSize.Height);

            var imageScaledSize = _mapSize * backgroundImageScale;

            var backgroundOffset = ((pbSize - imageScaledSize) / 2);

            return new Point(
                (int)((p.X - backgroundOffset.Width) / backgroundImageScale),
                (int)((p.Y - backgroundOffset.Height) / backgroundImageScale)
                );
        }

        // This is where we draw the dragbox and all of the coordinates. This was originally a Panel, and had terrible flicker. PictureBox is so much better
        private void pbMap_Paint(object sender, PaintEventArgs e)
        {
            var pb = sender as PictureBox;

            var g = e.Graphics;

            var topLeftHandleDisplayPoint = ConvertMapPointToDisplayPoint(_topLeftHandle, pb);
            var bottomRightHandleDisplayPoint = ConvertMapPointToDisplayPoint(_bottomRightHandle, pb);

            // This is where we make things look nice. Sorry, I meant "nice".
            var framePen = new Pen(Brushes.HotPink, 3);
            var textBrush = Brushes.Black;
            var markerBrush = Brushes.White;
            var backgroundBrush = Brushes.White;
            var font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);

            // Draw the drag box
            g.DrawRectangle(framePen, Rectangle.FromLTRB(
                topLeftHandleDisplayPoint.X,
                topLeftHandleDisplayPoint.Y,
                bottomRightHandleDisplayPoint.X,
                bottomRightHandleDisplayPoint.Y));

            // Draw each location on the map
            foreach (var mark in _marks)
            {
                var markPoint = new PointF(mark.Location.X, mark.Location.Y);
                var mapPoint = ConvertMarkPointToMapPoint(markPoint, _scale, _offsets);
                var displayPoint = ConvertMapPointToDisplayPoint(mapPoint, pb);

                // Draw the map circle
                g.FillEllipse(markerBrush, new Rectangle(displayPoint.X - 5, displayPoint.Y - 5, 10, 10));

                // Draw the map label, with a background so you can actually read it.
                // I spent a long time seeing if I could make the box partially transparent. I couldn't. I bet I could if I panted on an actual image. I wonder if it would flicker.
                var size = g.MeasureString(mark.Name, font);
                var textPosition = new Point(displayPoint.X + 6, (int)(displayPoint.Y - size.Height / 2));
                g.FillRectangle(backgroundBrush, Rectangle.FromLTRB(
                    textPosition.X, textPosition.Y, (int)(textPosition.X + size.Width), (int)(textPosition.Y + size.Height)));
                g.DrawString(mark.Name, font, textBrush, textPosition);
            }
        }

        // When the mouse moves, we either are going to change to hovers for the drag box, or move the drag box.
        private void pbMap_MouseMove(object sender, MouseEventArgs e)
        {
            var mappedPoint = ConvertDisplayPointToMapPoint(e.Location, sender as PictureBox);

            if (_holding == GrabLocation.None)
            {
                var hovering = GetHoveringHandle(mappedPoint, _topLeftHandle, _bottomRightHandle);
                Cursor.Current = hovering switch
                {
                    GrabLocation.Left => Cursors.SizeWE,
                    GrabLocation.Right => Cursors.SizeWE,
                    GrabLocation.Top => Cursors.SizeNS,
                    GrabLocation.Bottom => Cursors.SizeNS,
                    GrabLocation.TopLeft => Cursors.SizeNWSE,
                    GrabLocation.TopRight => Cursors.SizeNESW,
                    GrabLocation.BottomLeft => Cursors.SizeNESW,
                    GrabLocation.BottomRight => Cursors.SizeNWSE,
                    GrabLocation.None => Cursors.Default
                };
                return;
            }

            // In each of the below cases, we are making sure the drag box doesn't go outside the image or past the opposite corner 
            if (_holding == GrabLocation.Left || _holding == GrabLocation.TopLeft || _holding == GrabLocation.BottomLeft)
            {
                _topLeftHandle.X = Math.Max(0, Math.Min(mappedPoint.X, _bottomRightHandle.X - 5));
            }

            if (_holding == GrabLocation.Right || _holding == GrabLocation.TopRight || _holding == GrabLocation.BottomRight)
            {
                _bottomRightHandle.X = Math.Min((int)_mapSize.Width, Math.Max(mappedPoint.X, _topLeftHandle.X + 5));
            }

            if (_holding == GrabLocation.Top || _holding == GrabLocation.TopLeft || _holding == GrabLocation.TopRight)
            {
                _topLeftHandle.Y = Math.Max(0, Math.Min(mappedPoint.Y, _bottomRightHandle.Y - 5));
            }

            if (_holding == GrabLocation.Bottom || _holding == GrabLocation.BottomLeft || _holding == GrabLocation.BottomRight)
            {
                _bottomRightHandle.Y = Math.Min((int)_mapSize.Height, Math.Max(mappedPoint.Y, _topLeftHandle.Y + 5));
            }

            // We know where the box will be, now get the scale and offset from them. So that we can put them in the textbox, and redraw the points.

            (_scale, _offsets) = CalculateScaleAndOFfset(_marks, _topLeftHandle, _bottomRightHandle);

            // Update the image.
            pbMap.Refresh();
        }

        // When the mouse is released, release any corner you were holding
        private void pbMap_MouseUp(object sender, MouseEventArgs e)
        {
            _holding = GrabLocation.None;
        }

        // When mouse is down, figure out if we are clicking on any of the grab locations
        private void pbMap_MouseDown(object sender, MouseEventArgs e)
        {
            var mappedPoint = ConvertDisplayPointToMapPoint(e.Location, sender as PictureBox);

            _holding = GetHoveringHandle(mappedPoint, _topLeftHandle, _bottomRightHandle);
        }

        // Testing, please ignore.
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var fileBytes = File.ReadAllBytes("C:\\temp\\map_en.png");
            var memoryStream = new MemoryStream(fileBytes);
            SKBitmap image = SKBitmap.Decode(memoryStream);
        }

        // Yeah, this was a lot more complicated when I was doing some stuff in the past. But I don't have resharper to inline it, so ... just don't look here.
        private float GetDistance(int x, int y) => Math.Abs(x - y);

        // This ... does what it says on the tin.
        private GrabLocation GetHoveringHandle(Point mouse, Point p1, Point p2)
        {
            var targetDistance = 15;
            var distanceToLeft = GetDistance(p1.X, mouse.X);
            var distanceToRight = GetDistance(p2.X, mouse.X);
            var distanceToTop = GetDistance(p1.Y, mouse.Y);
            var distanceToBottom = GetDistance(p2.Y, mouse.Y);

            var grabbingLeft = false;
            var grabbingRight = false;
            var grabbingTop = false;
            var grabbingBottom = false;

            if (distanceToLeft < distanceToRight && distanceToLeft < targetDistance)
            {
                grabbingLeft = true;
            }
            else if (distanceToRight < distanceToLeft && distanceToRight < targetDistance)
            {
                grabbingRight = true;
            }


            if (distanceToTop < distanceToBottom && distanceToTop < targetDistance)
            {
                grabbingTop = true;
            }
            else if (distanceToBottom < distanceToTop && distanceToBottom < targetDistance)
            {
                grabbingBottom = true;
            }

            return (grabbingLeft, grabbingRight, grabbingTop, grabbingBottom) switch
            {
                (true, _, true, _) => GrabLocation.TopLeft,
                (true, _, _, true) => GrabLocation.BottomLeft,
                (_, true, true, _) => GrabLocation.TopRight,
                (_, true, _, true) => GrabLocation.BottomRight,
                (true, _, _, _) => GrabLocation.Left,
                (_, true, _, _) => GrabLocation.Right,
                (_, _, true, _) => GrabLocation.Top,
                (_, _, _, true) => GrabLocation.Bottom,
                _ => GrabLocation.None
            };
        }
    }
}