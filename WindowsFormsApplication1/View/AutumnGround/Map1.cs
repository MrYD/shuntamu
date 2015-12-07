using System.Drawing;
using shuntamu.View.AutumnGround.Charactors;

namespace shuntamu.View.AutumnGround
{
    class Map1 : MapBase
    {
        public Map1()
            : base(100)
        {
            var saveObject1 = new SaveObject(new Point(1408, 480)).AddTo(this);
            var saveObject2 = new SaveObject(new Point(3744, 448)).AddTo(this);
            var saveObject3 = new SaveObject(new Point(2560, 224)).AddTo(this);

            var eringi1 = new MotionlessKiller(new Point(448, 224),Skin.Eringi).AddTo(this);
            var eringi2 = new MotionlessKiller(new Point(800, 480),Skin.Eringi).AddTo(this);
            var eringi3 = new MotionlessKiller(new Point(1536,288),Skin.Eringi).AddTo(this);
            var eringi4 = new MotionlessKiller(new Point(1696, 544),Skin.Eringi).AddTo(this);
            var eringi5 = new MotionlessKiller(new Point(1728,544),Skin.Eringi).AddTo(this);
            var eringi6 = new MotionlessKiller(new Point(2496,544),Skin.Eringi).AddTo(this);
            var eringi7 = new LongEringi(new Point(2560,416)).AddTo(this);
            var eringi8 = new EringiDown(new Point(896,352)).AddTo(this);
            var eringi9 = new EringiLeft(new Point(1440,352)).AddTo(this);
            var eringi10 = new EringiRight(new Point(1984,192)).AddTo(this);
            var eringi13 = new EringiDown(new Point(1760,0)).AddTo(this);
            var eringi14 = new EringiDown(new Point(1792, 0)).AddTo(this);
            var eringi15 = new EringiDown(new Point(1824, 0)).AddTo(this);

            var invisBlock1 = new InvisibleBlock(new Point(0, 64)).AddTo(this);
            var invisBlock2 = new InvisibleBlock(new Point(0, 96)).AddTo(this);
            var invisBlock3 = new InvisibleBlock(new Point(0, 128)).AddTo(this);
            var invisBlock4 = new InvisibleBlock(new Point(0, 160)).AddTo(this);

            var dropEringi1 = new MotionKiller(new Point(2432,320),new Point(2464,352),new Size(32,64),0,5).AddTo(this);
            var vanEringi1 = new VanishKiller(new Point(224,160),new Point(128,96), new Size(32,32) ).AddTo(this);


            var clearObject1 = new ClearObject(new Point(6016,192)).AddTo(this);

            var dropEingi1 = new DropEryngii(new Point(2432,320),new Point(2464,352),new Size(32,64)).AddTo(this);
            var floor1 = new Rock1(new Point(0,0), new Size(736, 64)).AddTo(this);
            var floor2 = new Rock1(new Point(0,192), new Size(256, 416)).AddTo(this);
            var floor3 = new Rock1(new Point(352,256),new Size(224,352) ).AddTo(this);
            var floor4 = new Rock1(new Point(704,512), new Size(320, 96)).AddTo(this);
            var floor5 = new Rock1(new Point(736,0),new Size(256,352) ).AddTo(this);
            var floor6 = new Rock1(new Point(1024,416),new Size(32,192) ).AddTo(this);
            var floor7 = new Rock1(new Point(1056,384),new Size(256,224) ).AddTo(this);
            var floor8 = new Rock1(new Point(1312,416),new Size(32,192) ).AddTo(this);
            var floor9 = new Rock1(new Point(1344,512),new Size(352,96) ).AddTo(this);
            var floor10 = new Rock1(new Point(992,0),new Size(224,192) ).AddTo(this);
            var floor11 = new Rock1(new Point(1216,0),new Size(192,192) ).AddTo(this);
            var floor12 = new Rock1(new Point(1408,0),new Size(64,352) ).AddTo(this);
            var floor13 = new Rock1(new Point(1504,256),new Size(32,160) ).AddTo(this);
            var floor14 = new Rock1(new Point(1536,320),new Size(224,96) ).AddTo(this);
            var floor15 = new Rock1(new Point(1472,192),new Size(32,224) ).AddTo(this);
            var floor16 = new Rock1(new Point(1472,0),new Size(288,64) ).AddTo(this);
            var floor17 = new Rock1(new Point(1760,512),new Size(64,96) ).AddTo(this);
            var floor18 = new Rock1(new Point(1824,448),new Size(32,160) ).AddTo(this);
            var floor19 = new Rock1(new Point(1856,384),new Size(32,224) ).AddTo(this);
            var floor20 = new Rock1(new Point(1888,128),new Size(64,480) ).AddTo(this);
            var floor21 = new Rock1(new Point(1600,128),new Size(288,96) ).AddTo(this);
            var floor22 = new Rock1(new Point(1952,128),new Size(32,128) ).AddTo(this);
            var floor23 = new Rock1(new Point(1952,352),new Size(32,256) ).AddTo(this);
            var floor24 = new Rock1(new Point(1984,416),new Size(32,192) ).AddTo(this);
            //var floor25 = new Rock1(new Point(2016,448),new Size(32,160) ).AddTo(this);
            var floor26 = new Rock1(new Point(2016,512),new Size(160,96) ).AddTo(this);
            var floor27 = new Rock1(new Point(1984,128),new Size(224,64) ).AddTo(this);
            var floor28 = new Rock1(new Point(2080,352),new Size(96,64) ).AddTo(this);
            var floor29 = new Rock1(new Point(2304,416),new Size(160,64) ).AddTo(this);
            var floor30 = new Rock1(new Point(2176,576),new Size(352,32) ).AddTo(this);
            var floor31 = new Rock1(new Point(2304,256),new Size(256,64) ).AddTo(this);
            var floor32 = new Rock1(new Point(2528,480),new Size(64,128) ).AddTo(this);
            var floor33 = new Rock1(new Point(2560,256),new Size(32,96) ).AddTo(this);
            var floor34 = new Rock1(new Point(1856,0),new Size(160,64) ).AddTo(this);
            var floor35 = new Rock1(new Point(2016,0),new Size(256,32) ).AddTo(this);
            var floor36 = new Rock1(new Point(2272,0),new Size(224,160) ).AddTo(this);
            var floor37 = new Rock1(new Point(2496,0),new Size(224,160) ).AddTo(this);
            var floor38 = new Rock1(new Point(2720,0),new Size(224,160) ).AddTo(this);
            var floor39 = new Rock1(new Point(2944,0),new Size(224,160) ).AddTo(this);
            var floor40 = new Rock1(new Point(3168,0),new Size(224,160) ).AddTo(this);
            var floor41 = new Rock1(new Point(2912,256),new Size(192,352) ).AddTo(this);
            var floor42 = new Rock1(new Point(3104,256),new Size(32,96) ).AddTo(this);
            var floor43 = new Rock1(new Point(3360,480),new Size(32,32) ).AddTo(this);
            //var floor44 = new Rock1(new Point(3456,480),new Size(32,32) ).AddTo(this);
            var floor45 = new Rock1(new Point(3648,480),new Size(192,128) ).AddTo(this);
            var floor46 = new Rock1(new Point(3840, 416), new Size(32, 192)).AddTo(this);
            var floor47 = new Rock1(new Point(3872,352),new Size(64,256) ).AddTo(this);
            var floor48 = new Rock1(new Point(3392,0),new Size(192,320) ).AddTo(this);
            var floor49 = new Rock1(new Point(3584,0),new Size(192,320) ).AddTo(this);
            var floor50 = new Rock1(new Point(3776,256),new Size(32,64) ).AddTo(this);
            var floor51 = new Rock1(new Point(3776,0),new Size(320,64) ).AddTo(this);
            var floor52 = new Rock1(new Point(4096,0),new Size(320,64) ).AddTo(this);
            var floor53 = new Rock1(new Point(3872,160),new Size(64,64) ).AddTo(this);
            var floor54 = new Rock1(new Point(3936,160),new Size(64,448) ).AddTo(this);
            var floor55 = new Rock1(new Point(4000,160),new Size(192,96) ).AddTo(this);
            var floor56 = new Rock1(new Point(4046,352),new Size(128,96) ).AddTo(this);
            var floor57 = new Rock1(new Point(4288,160),new Size(64,96) ).AddTo(this);
            var floor58 = new Rock1(new Point(4000,512),new Size(576,96) ).AddTo(this);
            var floor59 = new Rock1(new Point(4288,352),new Size(128,96) ).AddTo(this);
            var floor60 = new Rock1(new Point(4416,0),new Size(64,448) ).AddTo(this);
            var floor61 = new Rock1(new Point(4480,0),new Size(128,288) ).AddTo(this);
            var floor62 = new Rock1(new Point(4608,0),new Size(224,288) ).AddTo(this);
            var floor63 = new Rock1(new Point(4576,448),new Size(32,160)).AddTo(this);
            var floor64 = new Rock1(new Point(4704,448),new Size(32,160) ).AddTo(this);
            var floor65 = new Rock1(new Point(4608,384),new Size(96,224) ).AddTo(this);
            var floor66 = new Rock1(new Point(4736,512),new Size(608,96)).AddTo(this);
            var floor67 = new Rock1(new Point(4832,0),new Size(224,480) ).AddTo(this);
            var floor68 = new Rock1(new Point(5056,0),new Size(64,384)).AddTo(this);
            var floor69 = new Rock1(new Point(5120,0),new Size(128,480) ).AddTo(this);
            var floor70 = new Rock1(new Point(5248,352),new Size(32,64) ).AddTo(this);
            var floor71 = new Rock1(new Point(5248,0),new Size(320,160) ).AddTo(this);
            var floor72 = new Rock1(new Point(5344,448), new Size(32, 160)).AddTo(this);
            var floor73 = new Rock1(new Point(5376,256),new Size(256,352) ).AddTo(this);
            var floor74 = new Rock1(new Point(5344,256),new Size(32,64) ).AddTo(this);
            var floor75 = new Rock1(new Point(5792,256),new Size(288,352) ).AddTo(this);
            var floor76 = new Rock1(new Point(2592,256),new Size(64,352) ).AddTo(this);
            var floor77 = new Rock1(new Point(1696,576),new Size(64,32) ).AddTo(this);

            var eringi11 = new MotionlessKiller(new Point(1792,160), Skin.Eringi).AddTo(this);
            var eringi12 = new MotionlessKiller(new Point(1824, 160), Skin.Eringi).AddTo(this);
            var vanfloor1 = new VanishBlock(new Point(1696, 512), new Size(64, 32)).AddTo(this);
            var vanfloor2 = new VanishBlock(new Point(1760,0),new Size(96,64) ).AddTo(this);

            var movingfloor1 = new MovingFloor(new Point(2726,256),Size).AddTo(this);
            var movingfloor2 = new MovingFloor(new Point(3136, 480), Size).AddTo(this);
            var movingfloor3 = new MovingFloor(new Point(3456, 480), Size).AddTo(this);
            var boss = new Boss(new Point(5916, 92)).AddTo(this);
            UpdateElement();
        }
    }
}
