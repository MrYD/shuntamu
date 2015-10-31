using System.Drawing;
using shuntamu.View.AutumnGround.Charactors;

namespace shuntamu.View.AutumnGround
{
    class Map1 : MapBase
    {
        public Map1()
            : base(100)
        {
            var saveObject1 = new SaveObject(new Point(1408,480));
            var saveObject2 = new SaveObject(new Point(3744,448));
            var floor1 = new Floor(new Point(0,0), new Size(1760, 64));
            var floor2 = new MotionlessObject(new Point(0,192), new Size(256, 416));
            var floor3 = new MotionlessObject(new Point(352,256),new Size(224,352) );
            var floor4 = new MotionlessObject(new Point(704,512), new Size(320, 96));
            var floor5 = new MotionlessObject(new Point(736,64),new Size(256,288) );
            var floor6 = new MotionlessObject(new Point(1024,416),new Size(320,192) );
            var floor7 = new MotionlessObject(new Point(1056,384),new Size(256,32) );
            var floor8 = new MotionlessObject(new Point(1344,512),new Size(352,96) );
            var floor9 = new Floor(new Point(992,64),new Size(480,128) );
            var floor10 = new MotionlessObject(new Point(1408,192),new Size(96,128) );
            var floor11 = new MotionlessObject(new Point(1504,256),new Size(32,64) );
            var floor12 = new MotionlessObject(new Point(1472,320),new Size(288,96) );
            var floor13 = new Floor(new Point(1760,512),new Size(416,96) );
            var floor14 = new MotionlessObject(new Point(1824,448),new Size(224,64) );
            var floor15 = new MotionlessObject(new Point(1856,384),new Size(160,64) );
            var floor16 = new MotionlessObject(new Point(1888,224),new Size(64,160) );
            var floor17 = new MotionlessObject(new Point(1600,128),new Size(384,96) );
            var floor18 = new MotionlessObject(new Point(1984,128),new Size(224,64) );
            var floor19 = new MotionlessObject(new Point(2080,320),new Size(96,64) );
            var floor20 = new MotionlessObject(new Point(2304,416),new Size(160,64) );
            var floor21 = new MotionlessObject(new Point(2304,576),new Size(224,32) );
            var floor22 = new MotionlessObject(new Point(2304,256),new Size(256,64) );
            var floor23 = new MotionlessObject(new Point(2528,480),new Size(128,128) );
            var floor24 = new MotionlessObject(new Point(2560,256),new Size(96,96) );
            var floor25 = new MotionlessObject(new Point(1856,0),new Size(160,64) );
            var floor26 = new MotionlessObject(new Point(2016,0),new Size(256,32) );
            var floor27 = new Floor(new Point(2272,0),new Size(1120,160) );
            var floor28 = new MotionlessObject(new Point(2912,256),new Size(192,352) );
            var floor29 = new MotionlessObject(new Point(3104,256),new Size(32,96) );
            var floor30 = new MotionlessObject(new Point(3264,480),new Size(32,32) );
            var floor31 = new MotionlessObject(new Point(3456,480),new Size(32,32) );
            var floor32 = new MotionlessObject(new Point(3648,480),new Size(192,128) );
            var floor33 = new MotionlessObject(new Point(3840, 416), new Size(32, 192));
            var floor34 = new MotionlessObject(new Point(3872,352),new Size(64,256) );
            var floor35 = new Floor(new Point(3392,0),new Size(384,320) );
            var floor36 = new MotionlessObject(new Point(3776,256),new Size(32,64) );
            var floor37 = new Floor(new Point(3776,0),new Size(640,64) );
            var floor38 = new MotionlessObject(new Point(3872,160),new Size(64,64) );
            var floor39 = new MotionlessObject(new Point(3936,160),new Size(64,448) );
            var floor40 = new MotionlessObject(new Point(4000,160),new Size(192,96) );
            var floor41 = new MotionlessObject(new Point(4046,352),new Size(128,96) );
            var floor42 = new MotionlessObject(new Point(4288,160),new Size(64,96) );
            var floor43 = new Floor(new Point(4000,512),new Size(576,96) );
            var floor44 = new MotionlessObject(new Point(4288,352),new Size(128,96) );
            var floor45 = new MotionlessObject(new Point(4416,0),new Size(64,448) );
            var floor46 = new MotionlessObject(new Point(4480,0),new Size(352,288) );
            var floor47 = new MotionlessObject(new Point(4576,448),new Size(160,160));
            var floor48 = new MotionlessObject(new Point(4608,384),new Size(96,64) );
            var floor49 = new Floor(new Point(4736,512),new Size(608,96));
            var floor50 = new MotionlessObject(new Point(4832,0),new Size(224,480) );
            var floor51 = new MotionlessObject(new Point(5056,0),new Size(64,384));
            var floor52 = new MotionlessObject(new Point(5120,0),new Size(128,480) );
            var floor53 = new MotionlessObject(new Point(5248,352),new Size(32,64) );
            var floor54 = new MotionlessObject(new Point(5248,0),new Size(320,160) );
            var floor55 = new MotionlessObject(new Point(5344,448), new Size(288, 160));
            var floor56 = new MotionlessObject(new Point(5376,320),new Size(256,128) );
            var floor57 = new MotionlessObject(new Point(5344,256),new Size(288,64) );
            var floor58 = new MotionlessObject(new Point(5792,256),new Size(288,352) );

            AddElement(saveObject1);
            AddElement(saveObject2);
            AddElement(floor1);
            AddElement(floor2);
            AddElement(floor3);
            AddElement(floor4);
            AddElement(floor5);
            AddElement(floor6);
            AddElement(floor7);
            AddElement(floor8);
            AddElement(floor9);
            AddElement(floor10);
            AddElement(floor11);
            AddElement(floor12);
            AddElement(floor13);
            AddElement(floor14);
            AddElement(floor15);
            AddElement(floor16);
            AddElement(floor17);
            AddElement(floor18);
            AddElement(floor19);
            AddElement(floor20);
            AddElement(floor21);
            AddElement(floor22);
            AddElement(floor23);
            AddElement(floor24);
            AddElement(floor25);
            AddElement(floor26);
            AddElement(floor27);
            AddElement(floor28);
            AddElement(floor29);
            AddElement(floor30);
            AddElement(floor31);
            AddElement(floor32);
            AddElement(floor33);
            AddElement(floor34);
            AddElement(floor35);
            AddElement(floor36);
            AddElement(floor37);
            AddElement(floor38);
            AddElement(floor39);
            AddElement(floor40);
            AddElement(floor41);
            AddElement(floor42);
            AddElement(floor43);
            AddElement(floor44);
            AddElement(floor45);
            AddElement(floor46);
            AddElement(floor47);
            AddElement(floor48);
            AddElement(floor49);
            AddElement(floor50);
            AddElement(floor51);
            AddElement(floor52);
            AddElement(floor53);
            AddElement(floor54);
            AddElement(floor55);
            AddElement(floor56);
            AddElement(floor57);
            AddElement(floor58);

            UpdateElement();
        }
    }
}
