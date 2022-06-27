using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigGameProject
{
    public partial class BigGameProject : Form
    {
        Bitmap off;
        Timer tt = new Timer();
        Random RR;
        bool iDrag = false;
        int prevX, prevY;
        bool Lose = false;
        bool Won = false;

        int ctTimer = 0;
        int ctLaser = 0;
        int ctCrawl = 0;

        int PrisonDir = 0;
        int PrisonSpeed = 1;
        int ScrollSpeed = 5;

        int NHeroWalk = 8;
        int NHeroRun = 8;
        int NHeroJump = 14;
        int NHeroCrawl = 7;
        int NHeroShotM = 5;
        int Lasers = 4;
        int NHeroShotS = 11;
        int NHeroLadderClimb = 7;
        int NHeroPaddling = 11;
        int NHeroSwim = 5;
        int Lights = 3;

        int NEnemyRock = 10;
        int NEnemyFire = 8;

        int DestX = 0;
        int DestY = 0;

        bool Start = true;
        bool StartAnimation = false;

        bool HeroRightMoved = false;
        bool HeroLeftMoved = false;
        bool HeroJumped = false;
        bool HeroSpeeded = false;
        bool SaveSpeedAfterJump = false;
        bool DoubleJumpTime = false;
        bool HeroDoubleJumped = false;
        bool HeroCrawled = false;
        bool HeroStartShotM = false;
        bool HeroStartShotS = false;
        bool HeroArrowStartMove = false;
        bool HeroArrowDir = false;

        bool HideScopeLine = false;
        int ArrowScopedSpeed = 100;
        bool HideScopeImg = false;
        bool QueueStartScopeShot = false;
        int iScopeImg = -1;
        int ctScopeImg = 0;
        bool ArrowScopeImginAir = false;

        int ctDClick = 0;
        int DClick = 0;
        int vDClick = 1;


        bool LaserEnabled = false;
        bool LaserCharged = true;
        bool RunCharged = true;

        bool FreezeJump = false;
        int VJump = 50;

        bool LadderOn = false;
        int ctLadder = 0;
        bool NearLadder = false;

        bool FromTreeFall = false;

        bool EnemyRockDied = false;
        bool EnemyFlameDied = false;

        int RockSpeed = 50;
        int FlameSpeed = 30;

        int ctGroundTree = 0;

        bool BridgeOn = false;
        int BridgeSpeed = 12;
        bool FlyOn = false;
        int ctBridge = 0;

        bool SeaArea = false;
        int PaddlingSpeed = 10;

        bool SwimOn = false;
        bool FirstSwimFall = true;
        bool SwimAccelerateRight = false;
        bool SwimAccelerateLeft = false;
        bool SwimAccelerateUp = false;
        bool SwimAccelerateDown = false;
        int ctSwim1 = 0;
        int ctSwim2 = 0;
        int ctSwim3 = 0;
        int ctSwim4 = 0;

        bool SwimW = false;
        bool SwimS = false;
        bool SwimD = false;
        bool SwimA = false;


        bool Level4 = false;


        Bitmap BG = new Bitmap("Backgrounds\\BG-min.jpg");

        class StartPage
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public string st;
            public Color clr;
        }

        class Hero
        {
            public int X;
            public int Y;
            public int iAnimation;
            public int iFrame;
            public List<HAnimation> LAnimation = new List<HAnimation>();
            //public List<List<Bitmap>> Frames = new List<List<Bitmap>>();
        }

        class HAnimation
        {
            public int W;
            public int H;
            public List<HFrame> LFrame = new List<HFrame>();
        }

        class HFrame
        {
            public Bitmap im;
        }

        class Bar
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public Color clr;
            public string name;
            public List<Bar> Progress = new List<Bar>();
        }

        class Prison
        {
            public int X;
            public int Y;
            public int W;
            public int H;
        }

        class Laser
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public int colorNo;
            public List<Bitmap> colors;
        }

        class Score
        {
            public int X;
            public int Y;
            public int amount;
            public Color clr;
            public string st;
        }

        class HeroShot
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public Bitmap im;
        }

        class HeroArrow
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public Bitmap im;
        }

        class ScopeLine
        {
            public int X1;
            public int Y1;
            public int X2;
            public int Y2;
            public int dScopeX;
            public int dScopeXd;
        }

        class ScopeImg
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public int dScopeX;
            public int dScopeY;
            public int dScopeXd;
            public Bitmap im;
        }

        class Ladder
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public Bitmap im;
        }

        class HeroMessage
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public string st;
        }

        class HeroTreeBranch
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public Bitmap im;
        }

        class GroundTree
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public Bitmap im;
        }

        class EnemyTree
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public Bitmap im;
        }

        class EnemyRock
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public int Health;
            public int Delay;
            public int iFrame;
            public List<Bitmap> im;
        }

        class EnemyFlame
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public int Health;
            public int Delay;
            public int iFrame;
            public List<Bitmap> im;
        }

        class Rock
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public int dRockX;
            public int dRockXd;
            public int dRockY;
            public Bitmap im;
        }

        class Flame
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public Bitmap im;
        }

        class Fly
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public Bitmap im;
        }

        class Bridge
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public int Destroy;
            public int Delay;
            public Bitmap im;
        }

        class Rain
        {
            public int X;
            public int Y;
            public int W;
            public int H;
        }

        class Light
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public Bitmap im;
        }

        class Boat
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public int Health;
            public Bitmap im;
        }

        class Shark
        {
            public int X;
            public int Y;
            public int W;
            public int H;
            public Bitmap im;
        }


        List<StartPage> LSP = new List<StartPage>();
        List<Hero> LHero = new List<Hero>();
        List<Bar> LBars = new List<Bar>();
        List<Prison> LPrison = new List<Prison>();
        List<Laser> LLaser = new List<Laser>();
        List<Score> LScore = new List<Score>();
        List<HeroArrow> LHeroArrow = new List<HeroArrow>();
        List<ScopeLine> LScopeLine = new List<ScopeLine>();
        List<ScopeImg> LScopeImg = new List<ScopeImg>();
        List<Ladder> LLadder = new List<Ladder>();
        List<HeroMessage> LMessage = new List<HeroMessage>();
        List<HeroTreeBranch> LHeroTreeBranch = new List<HeroTreeBranch>();
        List<GroundTree> LGroundTree = new List<GroundTree>();
        List<EnemyTree> LEnemyTree = new List<EnemyTree>();
        List<EnemyRock> LEnemyRock = new List<EnemyRock>();
        List<EnemyFlame> LEnemyFlame = new List<EnemyFlame>();
        List<Rock> LRock = new List<Rock>();
        List<Flame> LFlame = new List<Flame>();
        List<Fly> LFly = new List<Fly>();
        List<Bridge> LBridge = new List<Bridge>();
        List<Rain> LRain = new List<Rain>();
        List<Light> LLight = new List<Light>();
        List<Boat> LBoat = new List<Boat>();


        public BigGameProject()
        {
            InitializeComponent();
            this.Paint += BigGameProject_Paint;
            this.KeyDown += BigGameProject_KeyDown;
            this.MouseDown += BigGameProject_MouseDown;
            this.MouseMove += BigGameProject_MouseMove;
            this.KeyUp += BigGameProject_KeyUp;
            this.MouseUp += BigGameProject_MouseUp;
            this.WindowState = FormWindowState.Maximized;
            tt.Tick += Tt_Tick;
            tt.Start();
        }
        

        private void BigGameProject_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            CreateStart();
        }

        private void BigGameProject_Paint(object sender, PaintEventArgs e)
        {
            DrawDouble(e.Graphics);
        }

        private void BigGameProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Start)
            {
                if (!Lose && !Won)
                {
                    if (e.KeyCode == Keys.D && !LadderOn && !FlyOn && !SeaArea && !SwimOn)
                    {
                        if (LHero[0].X > 1550)
                        {
                            Won = true;
                            MessageBox.Show("You Won", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                        HeroRightMoved = true;
                        HeroLeftMoved = false;
                        if (!HeroJumped && !HeroCrawled)
                        {
                            DClick = vDClick;
                        }
                        if (LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W > LHeroTreeBranch[0].X + LHeroTreeBranch[0].W - DestX
                            && LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W < LHeroTreeBranch[0].X + LHeroTreeBranch[0].W - DestX + 60)
                        {
                            FromTreeFall = true;
                        }
                        else
                        {
                            FromTreeFall = false;
                        }


                        if (!HeroCrawled)
                        {
                            if (HeroSpeeded)
                            {
                                if (LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W >= LGroundTree[0].X - DestX
                                    && LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W <= LGroundTree[0].X + 300 - DestX)
                                {
                                    if (DestX % 2 == 0)
                                    {
                                        LHero[0].Y -= 2;
                                    }
                                }
                                else if (LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W >= LGroundTree[0].X - DestX + 400
                                    && LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W <= LGroundTree[0].X + 700 - DestX)
                                {
                                    if (DestX % 2 == 0)
                                    {
                                        LHero[0].Y += 2;
                                    }
                                }
                            }
                            else
                            {
                                if (LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W >= LGroundTree[0].X - DestX
                                    && LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W <= LGroundTree[0].X + 300 - DestX)
                                {
                                    if (ctGroundTree % 2 == 0)
                                    {
                                        LHero[0].Y -= 4;
                                    }
                                    ctGroundTree++;
                                }
                                else if (LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W >= LGroundTree[0].X - DestX + 400
                                    && LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W <= LGroundTree[0].X + 690 - DestX)
                                {
                                    if (ctGroundTree % 2 == 0)
                                    {
                                        LHero[0].Y += 4;
                                    }
                                    ctGroundTree++;
                                }
                            }
                            
                        }
                        else
                        {
                            if (LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W >= LGroundTree[0].X - DestX
                                && LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W <= LGroundTree[0].X + 300 - DestX)
                            {
                                if (ctGroundTree % 2 == 0)
                                {
                                    LHero[0].Y -= 2;
                                }
                                ctGroundTree++;
                            }
                            else if (LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W >= LGroundTree[0].X - DestX + 400
                                && LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W <= LGroundTree[0].X + 690 - DestX)
                                 {
                                    if (ctGroundTree % 2 == 0)
                                    {
                                        LHero[0].Y += 2;
                                    }
                                ctGroundTree++;
                            }

                            
                        }

                        if(LHero[0].iAnimation == 0 || LHero[0].iAnimation == 1)
                        {
                            if(LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W >= LFly[0].X - DestX &&
                               LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W < LFly[0].X - DestX + LFly[0].W && 
                               !FlyOn && !BridgeOn)
                            {
                                LHero[0].X = LFly[0].X  - DestX - 35;
                                LHero[0].Y = LFly[0].Y - 190;
                                FlyOn = true;
                                LEnemyFlame.Clear();
                                LEnemyRock.Clear();
                            }
                        }

                        if (BridgeOn)
                        {
                            if (HeroSpeeded)
                            {
                                if (LHero[0].X > LBridge[0].X - DestX && LHero[0].X < LBridge[0].X + (LBridge[0].W / 2) - DestX)
                                {
                                    LHero[0].Y += 1;
                                }
                                else
                                {
                                    LHero[0].Y -= 1;
                                }
                            }
                            else
                            {
                                if (LHero[0].X > LBridge[0].X - DestX && LHero[0].X < LBridge[0].X + (LBridge[0].W / 2) - DestX - 500)
                                {
                                    
                                    LHero[0].Y += 1;
                                }
                                else if (LHero[0].X > LBridge[0].X - DestX + (LBridge[0].W / 2))
                                {
                                    if (ctBridge % 2 == 0)
                                    {
                                        LHero[0].Y -= 1;
                                    }
                                }
                            }
                                        ///////// --> HERE  
                           
                        }
                        if ((!Level4 && !SwimOn && !SeaArea && LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W > LBridge[0].X + LBridge[0].W - DestX))
                        {
                            BridgeOn = false;
                            LBridge.Clear();
                            SeaArea = true;
                            CreateBoat();
                            CreateRain();
                            CreateLight();
                            CreateHeroAnother();
                            LHero[0].X = LBoat[0].X - DestX;
                            LHero[0].Y = LBoat[0].Y - 120;
                            LHero[0].iFrame = 0;
                            LHero[0].iAnimation = 7;
                        }

                    }

                    if (e.KeyCode == Keys.A && !HeroStartShotM && !LadderOn && !FlyOn && !SeaArea && !SwimOn)
                    {
                       
                        if(LHero[0].Y == 320)
                        {
                            if(LHero[0].X >= LHeroTreeBranch[0].X - DestX)
                            {
                                HeroRightMoved = false;
                                HeroLeftMoved = true;
                                if (!HeroJumped && !HeroCrawled)
                                {
                                    LHero[0].iAnimation = 0;
                                }
                                HeroSpeeded = false;
                            }
                        }
                        else
                        {
                            HeroRightMoved = false;
                            HeroLeftMoved = true;
                            if (!HeroJumped && !HeroCrawled)
                            {
                                LHero[0].iAnimation = 0;
                            }
                            HeroSpeeded = false;
                        }

                        if (!HeroCrawled)
                        {
                                if (LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W >= LGroundTree[0].X - DestX
                                    && LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W <= LGroundTree[0].X + 300 - DestX)
                                {
                                    if (ctGroundTree % 2 == 0)
                                    {
                                        LHero[0].Y += 4;
                                    }
                                    ctGroundTree++;
                                }
                                else if (LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W >= LGroundTree[0].X - DestX + 400
                                    && LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W <= LGroundTree[0].X + 690 - DestX)
                                {
                                    if (ctGroundTree % 2 == 0)
                                    {
                                        LHero[0].Y -= 4;
                                    }
                                    ctGroundTree++;
                                }
                            

                        }
                        else
                        {
                            if (LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W >= LGroundTree[0].X - DestX
                                && LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W <= LGroundTree[0].X + 300 - DestX)
                            {
                                if (ctGroundTree % 2 == 0)
                                {
                                    LHero[0].Y += 2;
                                }
                                ctGroundTree++;
                            }
                            else if (LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W >= LGroundTree[0].X - DestX + 400
                                && LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W <= LGroundTree[0].X + 690 - DestX)
                            {
                                if (ctGroundTree % 2 == 0)
                                {
                                    LHero[0].Y -= 2;
                                }
                                ctGroundTree++;
                            }


                        }

                    }

                    if (e.KeyCode == Keys.Space && !HeroJumped && !HeroStartShotM && !LadderOn && !FlyOn && !BridgeOn && !SwimOn)
                    {

                        if (HeroCrawled)
                        {
                            HeroCrawled = false;
                            ScrollSpeed = 6;
                            LHero[0].Y -= 130;
                            LHero[0].iFrame = 0;
                            LHero[0].iAnimation = 0;
                            ctCrawl++;
                        }
                        LHero[0].iAnimation = 2;
                        LHero[0].iFrame = 0;
                        HeroJumped = true;
                        LHero[0].Y -= 50;
                        LHero[0].X -= 20;
                        VJump = 50;
                        if (HeroSpeeded)
                        {
                            SaveSpeedAfterJump = true;
                        }
                        HeroSpeeded = false;
                        ctDClick = 0;
                        DClick = 0;
                        LHero[0].iAnimation = 2;
                        vDClick = 1;
                        //LaserEnabled = false;
                        //LLaser.Clear();
                    }

                    if (e.KeyCode == Keys.Space && !HeroDoubleJumped && DoubleJumpTime && !LadderOn && !FlyOn && !BridgeOn && !SwimOn)
                    {
                        HeroDoubleJumped = true;
                        //LHero[0].Y -= 120;
                        VJump = 120;
                    }

                    if (e.KeyCode == Keys.L && (LHero[0].iAnimation == 0 || LHero[0].iAnimation == 1 || LHero[0].iAnimation == 7) && !LadderOn && !SwimOn)
                    {
                        if (!LaserEnabled && LaserCharged)
                        {
                            LaserEnabled = true;
                            ctLaser = 0;
                            CreateLaser();
                        }

                        if (LLaser.Count > 0)
                        {
                            LLaser[0].colorNo++;
                            if (LLaser[0].colorNo > 3)
                            {
                                LLaser[0].colorNo = 0;
                            }
                        }
                    }

                    if (e.KeyCode == Keys.C && !HeroJumped && !HeroSpeeded && !LadderOn && !FlyOn && !SwimOn)
                    {
                        if (ctCrawl % 2 == 0)
                        {
                            LHero[0].iFrame = 0;
                            LHero[0].iAnimation = 3;
                            LHero[0].Y += 130;
                            HeroCrawled = true;
                            ScrollSpeed = 4;
                        }
                        else
                        {
                            HeroCrawled = false;
                            ScrollSpeed = 6;
                            LHero[0].Y -= 130;
                            LHero[0].iFrame = 0;
                            LHero[0].iAnimation = 0;
                        }
                        ctCrawl++;
                    }

                    if (e.KeyCode == Keys.P && !HeroJumped && !HeroCrawled && !HeroLeftMoved && !SwimOn)
                    {
                        if (!HeroArrowDir)
                        {
                            HeroArrowDir = true;
                            LHero[0].iFrame = 0;
                            LHero[0].iAnimation = 4;
                            LHero[0].Y -= 50;
                            LHero[0].X -= 20;
                        }
                        HeroStartShotM = true;
                        //CreateArrow();            FOR MACHINE GUN
                    }

                    if (e.KeyCode == Keys.Return && LScopeImg.Count > 0 && ctScopeImg == 0 && !SwimOn)
                    {
                        LHero[0].iFrame = 0;
                        LHero[0].iAnimation = 5;
                        LHero[0].Y -= 50;
                        LHero[0].X -= 20;
                        // HideScopeImg = true;
                        QueueStartScopeShot = true;
                    }

                    if (e.KeyCode == Keys.Back && !LadderOn && !SwimOn)
                    {
                        LHeroArrow.Clear();
                        LScopeImg.Clear();
                        HideScopeImg = true;
                        QueueStartScopeShot = false;
                        LHero[0].iFrame = 0;
                        LHero[0].iAnimation = 0;
                        LHero[0].Y += 50;
                        LHero[0].X += 20;
                        ctScopeImg = 0;
                    }

                    if (e.KeyCode == Keys.U && NearLadder && !FlyOn && !BridgeOn && !SwimOn)
                    {
                        LMessage.Clear();
                        if (ctLadder % 2 == 0)
                        {
                            LadderOn = true;
                            LHero[0].iFrame = 0;
                            LHero[0].iAnimation = 6;
                            LHero[0].X = LLadder[0].X - DestX - (LHero[0].LAnimation[0].W / 2);
                            ctLadder++;
                            LHero[0].Y -= 50;
                        }
                        else
                        {
                            LadderOn = false;
                            LHero[0].iFrame = 0;
                            LHero[0].iAnimation = 0;
                            LHero[0].X = 40;
                            ctLadder++;
                            LHero[0].Y = this.ClientSize.Height - 270;
                        }

                    }

                    if (e.KeyCode == Keys.W && LadderOn && !FlyOn && !BridgeOn && !SwimOn)
                    {
                        LHero[0].iFrame++;
                        LHero[0].Y -= 15;
                        LHero[0].iAnimation = 6;
                        LHero[0].X = LLadder[0].X - DestX - 35;
                        if (LHero[0].iFrame >= NHeroLadderClimb)
                        {
                            LHero[0].iFrame = 2;
                        }
                        if (LHero[0].Y <= 362)
                        {
                            LadderOn = false;
                            LHero[0].iAnimation = 0;
                            LHero[0].iFrame = 0;
                            LHero[0].Y = 320;
                            DestX += 60;
                        }
                    }

                    if (e.KeyCode == Keys.S && LadderOn && LHero[0].Y < this.ClientSize.Height - 350 && !FlyOn && !BridgeOn && !SwimOn)
                    {
                        LHero[0].iFrame--;
                        LHero[0].iAnimation = 6;
                        LHero[0].Y += 15;
                        LHero[0].X = LLadder[0].X - DestX - 35;
                        if (LHero[0].iFrame < 2)
                        {
                            LHero[0].iFrame = 6;
                        }
                    }

                    if (e.KeyCode == Keys.D && SeaArea && !Level4 && !SwimOn)
                    {
                        LHero[0].iFrame++;
                        if(LHero[0].iFrame >= NHeroPaddling)
                        {
                            LHero[0].iFrame = 0;
                        }
                        LBoat[0].X += ScrollSpeed;
                        DestX += ScrollSpeed;
                        if(DestX > 5000)
                        {
                            SwimOn = false;
                            SeaArea = false;
                            Level4 = true;
                            LBoat.Clear();
                            LRain.Clear();
                            LLight.Clear();
                            DestX = 5670;
                            LHero[0].iAnimation = 0;
                            LHero[0].iFrame = 0;
                            LHero[0].X = 40;
                            LHero[0].Y = 757;
                        }
                    }

                    if (e.KeyCode == Keys.A && SeaArea && DestX > 3700 && !SwimOn)
                    {
                        LHero[0].iFrame--;
                        if (LHero[0].iFrame < 0)
                        {
                            LHero[0].iFrame = NHeroPaddling - 1;
                        }
                        LBoat[0].X -= ScrollSpeed;
                        DestX -= ScrollSpeed;
                    }

                    if (e.KeyCode == Keys.D && SwimOn)
                    {
                        LHero[0].iFrame++;
                        if(LHero[0].iFrame >= NHeroSwim)
                        {
                            LHero[0].iFrame = 0;
                        }
                        if (DestX < 5450)
                        {
                            DestX += ScrollSpeed + ctSwim1;
                            ctSwim1++;
                        }
                        SwimD = true;
                        SwimA = false;
                    }

                    if (e.KeyCode == Keys.A && SwimOn && DestX > 3800)
                    {
                        LHero[0].iFrame--;
                        if(LHero[0].iFrame < 0)
                        {
                            LHero[0].iFrame = NHeroSwim - 1;
                        }
                        DestX -= ScrollSpeed + ctSwim2;
                        ctSwim2 ++;

                        SwimA = true;
                        SwimD = false;
                    }

                    if (e.KeyCode == Keys.W && SwimOn && LHero[0].Y > 0)
                    {
                        SwimW = true;
                        SwimS = false;

                        if (DestX < 5450)
                        {
                            LHero[0].iFrame++;
                            if (LHero[0].iFrame >= NHeroSwim)
                            {
                                LHero[0].iFrame = 0;
                            }
                            if(SwimD && !SwimA)
                            {
                                LHero[0].X += ScrollSpeed + ctSwim3;
                            }
                            else if(!SwimD && SwimA)
                            {
                                LHero[0].X -= ScrollSpeed + ctSwim3;
                            }
                            LHero[0].Y -= ScrollSpeed + ctSwim3;
                            
                        }
                        else
                        {
                            LHero[0].iFrame++;
                            if (LHero[0].iFrame >= NHeroSwim)
                            {
                                LHero[0].iFrame = 0;
                            }
                            DestY -= ScrollSpeed + ctSwim3;
                            if (DestY < 400)
                            {
                                SwimOn = false;
                                LHero[0].iFrame = 0;
                                LHero[0].iAnimation = 0;
                                SwimAccelerateRight = false;
                                SwimAccelerateLeft = false;
                                SwimAccelerateUp = false;
                                SwimAccelerateLeft = false;
                                DestY = 0;
                                Level4 = true;
                                LHero[0].Y = 757;
                            }
                        }

                        ctSwim3++;
                    }

                    if (e.KeyCode == Keys.S && SwimOn && LHero[0].Y + LHero[0].LAnimation[8].H < this.ClientSize.Height)
                    {
                        
                        if (DestX < 5450)
                        {
                            LHero[0].iFrame--;
                            if (LHero[0].iFrame < 0)
                            {
                                LHero[0].iFrame = NHeroSwim - 1;
                            }
                            if(SwimD && !SwimA)
                            {
                                LHero[0].X += ScrollSpeed + ctSwim4;
                            }
                            else if(!SwimD && SwimA)
                            {
                                LHero[0].X -= ScrollSpeed + ctSwim4;
                            }

                            LHero[0].Y += ScrollSpeed + ctSwim4;
                            SwimS = true;
                            SwimW = false;
                        }
                        else
                        {
                            LHero[0].iFrame--;
                            if (LHero[0].iFrame < 0)
                            {
                                LHero[0].iFrame = NHeroSwim - 1;
                            }
                            DestY += ScrollSpeed + ctSwim4;
                        }
                        ctSwim4++;
                    }
                }
            }
        }

        private void BigGameProject_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Start)
            {
                if (e.KeyCode == Keys.D && !LadderOn && !SeaArea && !SwimOn)
                {
                    if (!HeroArrowDir)
                    {
                        if (!HeroJumped)
                        {
                            if (DClick == 1)
                            {
                                vDClick = 2;
                            }
                            else if (DClick == 2)
                            {
                                HeroSpeeded = false;
                                ctDClick = 0;
                                DClick = 0;
                                ScrollSpeed = 6;
                                LHero[0].iAnimation = 0;
                                vDClick = 1;
                                RunCharged = false;
                            }
                            LHero[0].iFrame = 0;
                        }

                        if (HeroSpeeded)
                        {
                            HeroSpeeded = false;
                            ctDClick = 0;
                            DClick = 0;
                            ScrollSpeed = 6;
                            LHero[0].iAnimation = 0;
                            vDClick = 1;
                            RunCharged = false;
                        }
                    }
                    HeroRightMoved = false;


                }

                if (e.KeyCode == Keys.A && !LadderOn && !SeaArea && !SwimOn)
                {
                    if (!HeroJumped)
                    {
                        HeroSpeeded = false;
                        ctDClick = 0;
                        DClick = 0;
                        LHero[0].iFrame = 0;
                    }
                    HeroLeftMoved = false;
                }

                if (e.KeyCode == Keys.P && !HeroJumped && !HeroCrawled && !SwimOn)
                {

                    LHero[0].iFrame = 0;
                    LHero[0].iAnimation = 0;
                    HeroStartShotM = false;
                    if (HeroArrowDir)
                    {
                        HeroArrowDir = false;
                        LHero[0].Y += 50;
                        LHero[0].X += 20;
                    }
                }

                if (e.KeyCode == Keys.D && SwimOn)
                {
                    SwimAccelerateRight = true;
                    LHero[0].iFrame = 0;
                    SwimD = false;
                }

                if (e.KeyCode == Keys.A && SwimOn)
                {
                    SwimAccelerateLeft = true;
                    LHero[0].iFrame = 0;
                    SwimA = false;
                }

                if (e.KeyCode == Keys.W && SwimOn)
                {
                    SwimAccelerateUp = true;
                    LHero[0].iFrame = 0;
                    SwimW = false;
                }

                if (e.KeyCode == Keys.S && SwimOn)
                {
                    SwimAccelerateDown = true;
                    LHero[0].iFrame = 0;
                    SwimS = false;
                }
            }
        }

        private void BigGameProject_MouseUp(object sender, MouseEventArgs e)
        {
            if (iDrag)
            {
                iDrag = false;
                HideScopeLine = true;
                HeroStartShotS = true;
                LHero[0].iAnimation = 5;
                LHero[0].Y -= 50;
                LHero[0].X -= 20;
                LScopeLine[0].dScopeX = LScopeLine[0].X2 - LScopeLine[0].X1;
                LScopeLine[0].dScopeXd = LScopeLine[0].dScopeX / ArrowScopedSpeed;
                //MessageBox.Show("" + LScopeLine[0].dScopeX + "  " + LScopeLine[0].dScopeXd + "  " + (LScopeLine[0].Y1 - LScopeLine[0].Y2));
                //LScopeLine.Clear();
            }
        }

        private void BigGameProject_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Lose && !Won)
            {
                if (Start)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (e.X >= LSP[1].X && e.X <= LSP[1].X + LSP[1].W
                        && e.Y >= LSP[1].Y && e.Y <= LSP[1].Y + LSP[1].H)
                        {
                            StartAnimation = true;
                            CreateHero();
                            CreateBars();
                            CreatePrison();
                            CreateScore();
                            CreateLadder();
                            CreateHeroTreeBranch();
                            CreateGroundTree();
                            CreateEnemyTree();
                            CreateEnemy();
                            CreateFly();
                            CreateBridge();
                        }
                    }
                }
                else
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if ((LHero[0].iAnimation == 0 || LHero[0].iAnimation == 6) && LHeroArrow.Count == 0)
                        {
                            if (e.X > LHero[0].X && e.X < LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W &&
                               e.Y > LHero[0].Y && e.Y < LHero[0].Y + LHero[0].LAnimation[LHero[0].iAnimation].H)
                            {
                                HideScopeLine = false;
                                prevX = e.X;
                                prevY = e.Y;
                                CreateScopeLine(e.X, e.Y);
                                iDrag = true;
                            }
                        }
                    }

                    if (e.Button == MouseButtons.Right && e.X >= LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W + 50)
                    {
                        if ((LHero[0].iAnimation == 0 || LHero[0].iAnimation == 6) && LHeroArrow.Count == 0)
                        {
                            HideScopeImg = false;
                            CreateScopeImg(e.X, e.Y);
                        }
                    }
                }
            }
        }

        private void BigGameProject_MouseMove(object sender, MouseEventArgs e)
        {
            //label1.Text = "X: " + e.X + "  Y:" + e.Y;
            if(Start)
            {
                if(e.X >= LSP[1].X && e.X <= LSP[1].X + LSP[1].W
                    && e.Y >= LSP[1].Y && e.Y <= LSP[1].Y + LSP[1].H)
                {
                    LSP[1].clr = Color.Gray;
                }
                else
                {
                    LSP[1].clr = Color.Black;
                }
                
            }
            else
            {
                if(iDrag)
                {
                    int dx = e.X - prevX;
                    int dy = e.Y - prevY;

                    if(e.X > prevX)
                    {
                        LScopeLine[0].X2 += dx;
                        prevX = e.X;
                    }
                    if(e.X < prevX && e.X >= LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W)
                    {
                        LScopeLine[0].X2 += dx;
                        prevX = e.X;
                    }
                    if(e.Y > prevY)
                    {
                        LScopeLine[0].Y2 += dy;
                        prevY = e.Y;
                    }
                    if (e.Y < prevY )
                    {
                        LScopeLine[0].Y2 += dy;
                        prevY = e.Y;
                    }
                }
            }
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            if (!Lose && !Won)
            {
                if (LHero.Count > 0)
                {
                    //label3.Text = "X: " + LHero[0].X + "  X + W:" + (LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W);
                    //label4.Text = "Y: " + LHero[0].Y + "  Y + H:" + (LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].H);
                    //label5.Text = "DestX: " + DestX;
                }
                if (ctTimer % 3 == 0)
                {
                    if (!Start)
                    {
                        LScore[0].amount++;
                    }
                }

                if (HeroRightMoved && !SeaArea && !SwimOn)
                {
                    MoveHero(1);
                }

                if (HeroLeftMoved && !SeaArea && !SwimOn)
                {
                    MoveHero(0);
                }

                if (!HeroArrowDir)
                {

                    if (HeroJumped)
                    {
                        JumpHero();
                    }
                }

                if (StartAnimation)
                {
                    Animate();
                }

                if (!Start && PrisonDir != 4)
                {
                    ClosePrison();
                }

                if (LaserEnabled)
                {
                    DoLaser();
                    ctLaser++;
                }

                if (!LaserCharged)
                {
                    RechargeLaser();
                }

                if (DClick == 1 && !HeroCrawled && !HeroArrowDir)
                {
                    ctDClick++;
                    RunHero();
                }

                if (DClick == 2 && !HeroCrawled && !HeroArrowDir)
                {
                    if (ctDClick < 5 && ctDClick != 0)
                    {
                        HeroSpeeded = true;
                    }
                    else
                    {
                        HeroSpeeded = false;
                        ctDClick = 0;
                        DClick = 0;
                        ScrollSpeed = 6;
                        LHero[0].iAnimation = 0;
                        vDClick = 1;
                    }

                }

                if (HeroSpeeded && !HeroCrawled && !HeroArrowDir)
                {
                    LHero[0].iAnimation = 1;
                    ScrollSpeed = 15;                                                                   
                    LBars[1].Progress[0].W -= 2;
                    if (LBars[1].Progress[0].W <= 0)
                    {
                        HeroSpeeded = false;
                        ctDClick = 0;
                        DClick = 0;
                        ScrollSpeed = 6;
                        LHero[0].iAnimation = 0;
                        vDClick = 1;
                        RunCharged = false;
                    }
                    if (DestX >= 1000 && DestX <= 1250)
                    {
                        if (DestX % 2 == 0)
                        {
                            LHero[0].Y -= 9;
                        }
                    }
                    else if (DestX >= 1450 && DestX <= 1700)
                    {
                        if (DestX % 2 == 0)
                        {
                            LHero[0].Y += 9;
                        }
                    }

                }

                if (!HeroSpeeded && !RunCharged)
                {
                    RechargedRun();
                }

                if (HeroStartShotM)
                {
                    HeroMShotAnimate();
                }

                if (LHeroArrow.Count > 0)
                {
                    MoveArrow();
                    CheckEnemyDied();
                }

                if (HeroStartShotS)
                {
                    HeroSShotAnimate();
                }

                if (QueueStartScopeShot && LScopeImg.Count != ctScopeImg)
                {
                    HeroSShotAnimate2();
                }
                else if (QueueStartScopeShot && LHeroArrow.Count == 0)
                {
                    LHero[0].iFrame = 0;
                    LHero[0].iAnimation = 0;
                    LHero[0].Y += 50;
                    LHero[0].X += 20;
                    QueueStartScopeShot = false;
                    LScopeImg.Clear();
                    ctScopeImg = 0;
                }

                if (FromTreeFall)
                {
                    LHero[0].Y += 50;
                    if (LHero[0].Y >= this.ClientSize.Height - 270)
                    {
                        LHero[0].Y = this.ClientSize.Height - 270;
                        FromTreeFall = false;
                    }
                }

                if (DestX > 0 && DestX < 1250 && !EnemyRockDied && LEnemyRock.Count > 0)
                {
                    if (LEnemyRock[0].Delay % 5 == 0)
                    {
                        LEnemyRock[0].Delay = 0;
                        LEnemyRock[0].iFrame++;
                        if (LEnemyRock[0].iFrame >= NEnemyRock)
                        {
                            LEnemyRock[0].iFrame = 0;
                        }
                        if (LEnemyRock[0].iFrame == NEnemyRock - 3)
                        {
                            CreateRock();
                            LEnemyRock[0].iFrame = 0;
                            LEnemyRock[0].Delay++;
                        }
                    }
                    else
                    {
                        LEnemyRock[0].Delay++;
                    }

                }               ////////////////////

                if (DestX > 0 && DestX < 920 && !EnemyFlameDied && LEnemyFlame.Count > 0)
                {
                    if (LEnemyFlame[0].Delay % 15 == 0)
                    {
                        LEnemyFlame[0].Delay = 0;
                        LEnemyFlame[0].iFrame++;
                        if (LEnemyFlame[0].iFrame >= NEnemyFire)
                        {
                            LEnemyFlame[0].iFrame = 0;
                        }
                        if (LEnemyFlame[0].iFrame == NEnemyFire - 1)
                        {
                            CreateFlame();
                            LEnemyFlame[0].iFrame = 7;
                            LEnemyFlame[0].Delay++;
                        }
                    }
                    else
                    {
                        LEnemyFlame[0].Delay++;
                    }

                }           ////////////////////

                if (ctTimer % 4 == 0 && LScore.Count > 0)
                {
                    LScore[0].clr = Color.White;
                }

                if (LRock.Count > 0)
                {
                    MoveRock();
                }

                if (LFlame.Count > 0)
                {
                    MoveFlame();
                }

                if (LHero.Count > 0 && LBars[0].Progress[0].W < 120)
                {
                    if(ctTimer % 250 == 0)
                    {
                        LBars[0].Progress[0].W += 10;
                    }
                }

                if (FlyOn)
                {
                    LHero[0].Y -= 15;
                    LFly[0].Y -= 15;
                    if(LFly[0].Y <= LBridge[0].Y + 70)
                    {
                        FlyOn = false;
                        LHero[0].X += 40;
                        BridgeOn = true;
                    }
                }

                if (LBridge.Count > 0 && BridgeOn)
                {
                    if (LBridge[0].Delay > 10)
                    {
                        LBridge[0].Destroy += BridgeSpeed;
                        if (LBridge[0].X - DestX + LBridge[0].Destroy > LHero[0].X + 100)
                        {
                            Lose = true;
                        }
                    }
                    else
                    {
                        LBridge[0].Delay++;
                    }
                }

                if (LFly.Count > 0 && !FlyOn && LFly[0].Y < (this.ClientSize.Height - 170))
                {
                    LFly[0].Y += 15;
                }

                if (BridgeOn && ctTimer % 2 == 0)
                {
                    ctBridge++;
                }

                if (SeaArea)
                {
                    LHero[0].iAnimation = 7;
                }

                if (SeaArea && !SwimOn)
                {
                    CreateRain();
                    FallRain();
                    if (ctTimer % 4 == 0)
                    {
                        LLight.Clear();
                    }

                    if (ctTimer % 20 == 0)
                    {
                        CreateLight();
                        ShineLight();
                    }
                    
                    if(ctTimer % 9 == 0)
                    {
                        LBoat[0].Health -= 2;
                        if(LBoat[0].Health <= 0)
                        {
                            SeaArea = false;
                            SwimOn = true;
                            LHero[0].iAnimation = 8;
                            LHero[0].iFrame = 0;
                            LBoat.Clear();
                            LRain.Clear();
                            LLight.Clear();
                        }
                    }
                }

                if (SwimOn && FirstSwimFall)
                {
                    if(DestY < 1100)
                    {
                        DestY += 100;
                    }
                    else
                    {
                        FirstSwimFall = false;
                    }
                }

                if(SwimOn && !FirstSwimFall)
                {
                    if(ctTimer % 20 == 0)
                    {
                        LBars[0].Progress[0].W -= 5;
                        if(LBars[0].Progress[0].W <= 0)
                        {
                            Lose = true;
                            MessageBox.Show("Drown");
                        }
                    }
                }

                if (SwimAccelerateRight)
                {
                    if (DestX < 5500)
                    {
                        if (ctSwim1 > 0)
                        {
                            DestX += ctSwim1;
                            ctSwim1 -= 1;
                        }
                        else
                        {
                            ctSwim1 = 0;
                            SwimAccelerateRight = false;
                        }
                    }
                    else
                    {
                        ctSwim1 = 0;
                        SwimAccelerateRight = false;
                    }
                }

                if (SwimAccelerateLeft)
                {
                    if (DestX > 3800)
                    {
                        if (ctSwim2 > 0)
                        {
                            DestX -= ctSwim2;
                            ctSwim2 -= 1;
                        }
                        else
                        {
                            ctSwim2 = 0;
                            SwimAccelerateLeft = false;
                        }
                    }
                    else
                    {
                        ctSwim2 = 0;
                        SwimAccelerateLeft = false;
                    }
                }

                if (SwimAccelerateUp)
                {
                    if (ctSwim3 > 0)
                    {
                       LHero[0].Y -= ctSwim3;
                       ctSwim3 -= 1;
                    }
                    else
                    {
                        ctSwim3 = 0;
                        SwimAccelerateUp = false;
                    }
                }
                else
                {
                   ctSwim3 = 0;
                   SwimAccelerateUp = false;
                }

                if (SwimAccelerateDown)
                {
                    if (ctSwim4 > 0)
                    {
                        LHero[0].Y += ctSwim4;
                        ctSwim4 -= 1;
                    }
                    else
                    {
                        ctSwim4 = 0;
                        SwimAccelerateDown = false;
                    }
                }
                else
                {
                    ctSwim4 = 0;
                    SwimAccelerateDown = false;
                }


                ctTimer++;
            }
            DrawDouble(this.CreateGraphics());

            
        }

        void CreateStart()
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    StartPage pnn = new StartPage();
                    pnn.X = this.ClientSize.Width / 2 - 200;
                    pnn.Y = 350;
                    LSP.Add(pnn);
                }
                if (i == 1)
                {
                    StartPage pnn = new StartPage();
                    pnn.X = this.ClientSize.Width / 2 - 100;
                    pnn.Y = this.ClientSize.Height / 2 - 25;
                    pnn.W = 200;
                    pnn.H = 50;
                    pnn.clr = Color.Black;
                    LSP.Add(pnn);
                }
                if (i == 2)
                {
                    StartPage pnn = new StartPage();
                    pnn.X = LSP[1].X + 7;
                    pnn.Y = LSP[1].Y + 6;
                    LSP.Add(pnn);
                }
            }
        }

        void Animate()
        {
            for(int i = 0; i < LSP.Count; i++)
            {
                LSP[i].X -= 80;
                LHero[0].X -= 55;
                if(LSP[i].X + LSP[1].W <= 0)
                {
                    Start = false;
                    LSP.Clear();
                }
            }
        }

        void CreateBars()
        {
            int BarWidth = 120;
            int BarHeight = 20;
            int BarX = 50;
            int BarY = 50;
            string[] ProgressColors = { "DarkRed", "Cyan", "LimeGreen" };
            string[] ProgressNames = { "Health", "Run", "Laser" };

            for (int i = 0; i < 3; i++)
            {
                Bar pnn = new Bar();
                pnn.X = BarX;
                pnn.Y = BarY;
                pnn.W = BarWidth;
                pnn.H = BarHeight;
                pnn.clr = Color.Black;
                pnn.name = ProgressNames[i];
                LBars.Add(pnn);
                BarY += 50;
            }

            for (int j = 0; j < 3; j++)
            {
                Bar pnn = new Bar();
                pnn.X = LBars[j].X;
                pnn.Y = LBars[j].Y;
                pnn.W = LBars[j].W;
                pnn.H = LBars[j].H;
                pnn.clr = Color.FromName(ProgressColors[j]);
                LBars[j].Progress.Add(pnn);
            }
        }

        void CreatePrison()
        {
            for (int i = 0; i < 1; i++)
            {
                Prison pnn = new Prison();
                pnn.X = this.ClientSize.Width;
                pnn.Y = this.ClientSize.Height - 20;
                pnn.W = 0;
                pnn.H = 20;
                LPrison.Add(pnn);
            }
            for (int i = 0; i < 1; i++)
            {
                Prison pnn = new Prison();
                pnn.X = 0;
                pnn.Y = this.ClientSize.Height - 20;
                pnn.W = 20;
                pnn.H = 0;
                LPrison.Add(pnn);
            }
            for (int i = 0; i < 1; i++)
            {
                Prison pnn = new Prison();
                pnn.X = 0;
                pnn.Y = 0;
                pnn.W = 0;
                pnn.H = 20;
                LPrison.Add(pnn);
            }
            for (int i = 0; i < 1; i++)
            {
                Prison pnn = new Prison();
                pnn.X = this.ClientSize.Width - 20;
                pnn.Y = 0;
                pnn.W = 20;
                pnn.H = 0;
                LPrison.Add(pnn);
            }
        }

        void ClosePrison()
        {
            if (PrisonDir == 0)
            {
                LPrison[PrisonDir].X -= PrisonSpeed;
                LPrison[PrisonDir].W += PrisonSpeed;

                if(LPrison[PrisonDir].X <= 0)
                {
                    PrisonDir = 1;
                }
            }
            else if(PrisonDir == 1)
            {
                LPrison[PrisonDir].Y -= PrisonSpeed;
                LPrison[PrisonDir].H += PrisonSpeed;

                if (LPrison[PrisonDir].Y <= 0)
                {
                    PrisonDir = 2;
                }
            }
            else if (PrisonDir == 2)
            {
                LPrison[PrisonDir].W += PrisonSpeed;

                if (LPrison[PrisonDir].X + LPrison[PrisonDir].W >= this.ClientSize.Width)
                {
                    PrisonDir = 3;
                }
            }
            else if (PrisonDir == 3)
            {
                LPrison[PrisonDir].H += PrisonSpeed;

                if (LPrison[PrisonDir].Y + LPrison[PrisonDir].H >= this.ClientSize.Height)
                {
                    PrisonDir = 4;
                    Lose = true;
                    MessageBox.Show("You lost because of the prison");
                }
            }
        }

        void CreateHero()
        {
            for (int i = 0; i < 1; i++)
            {
                Hero pnn = new Hero();
                pnn.X = this.ClientSize.Width + 40;
                pnn.Y = this.ClientSize.Height - 270;
                pnn.iFrame = 0;
                pnn.iAnimation = 0;
                LHero.Add(pnn);
            }

            int ax = 200;
            int ay = 250;
            for(int i = 0; i < 3; i++)                  // WALK + RUN + JUMP
            {
                HAnimation pnn = new HAnimation();
                pnn.W = ax;
                pnn.H = ay;
                LHero[0].LAnimation.Add(pnn);
                if(i == 1)
                {
                    ax += 50;
                    ay += 50;
                }
            }

            for (int i = 0; i < 1; i++)                  // Crawl
            {
                HAnimation pnn = new HAnimation();
                pnn.W = 300;
                pnn.H = 150;
                LHero[0].LAnimation.Add(pnn);
            }

            for (int i = 0; i < 2; i++)                  // Shot Multiple + Shot Single
            {
                HAnimation pnn = new HAnimation();
                pnn.W = 250;
                pnn.H = 300;
                LHero[0].LAnimation.Add(pnn);
            }

            for (int i = 0; i < 1; i++)                  // Climb Ladder
            {
                HAnimation pnn = new HAnimation();
                pnn.W = 150;
                pnn.H = 300;
                LHero[0].LAnimation.Add(pnn);
            }


            for (int i = 1; i <= NHeroWalk; i++)
            {
                HFrame pnn = new HFrame();
                pnn.im = new Bitmap("HeroWalk\\H" + i + ".png");
                LHero[0].LAnimation[0].LFrame.Add(pnn);
            }

            for (int i = 1; i <= NHeroRun; i++)
            {
                HFrame pnn = new HFrame();
                pnn.im = new Bitmap("HeroRun\\H" + i + ".png");
                LHero[0].LAnimation[1].LFrame.Add(pnn);
            }

            for (int i = 1; i <= NHeroJump; i++)
            {
                HFrame pnn = new HFrame();
                pnn.im = new Bitmap("HeroJump\\H" + i + ".png");
                LHero[0].LAnimation[2].LFrame.Add(pnn);
            }

            for (int i = 1; i <= NHeroCrawl; i++)
            {
                HFrame pnn = new HFrame();
                pnn.im = new Bitmap("HeroCrawl\\H" + i + ".png");
                LHero[0].LAnimation[3].LFrame.Add(pnn);
            }

            for (int i = 1; i <= NHeroShotM; i++)
            {
                HFrame pnn = new HFrame();
                pnn.im = new Bitmap("HeroShotM\\H" + i + ".png");
                LHero[0].LAnimation[4].LFrame.Add(pnn);
            }

            for (int i = 1; i <= NHeroShotS; i++)
            {
                HFrame pnn = new HFrame();
                pnn.im = new Bitmap("HeroShotS\\H" + i + ".png");
                LHero[0].LAnimation[5].LFrame.Add(pnn);
            }

            for (int i = 1; i <= NHeroLadderClimb; i++)
            {
                HFrame pnn = new HFrame();
                pnn.im = new Bitmap("HeroClimbLadder\\H" + i + ".png");
                LHero[0].LAnimation[6].LFrame.Add(pnn);
            }


        }

        void CreateScore()
        {
            Score pnn = new Score();
            pnn.X = this.ClientSize.Width - 200;
            pnn.Y = 50;
            pnn.st = "Score = ";
            pnn.clr = Color.White;
            pnn.amount = 0;
            LScore.Add(pnn);
        }

        void CreateLadder()
        {
            Ladder pnn = new Ladder();
            pnn.X = 600;
            pnn.Y = 500;
            pnn.W = 100;
            pnn.H = 400;
            pnn.im = new Bitmap("Climbs\\RopeLadder.png");
            pnn.im.MakeTransparent(pnn.im.GetPixel(0,0));
            LLadder.Add(pnn);
        }

        void MoveHero(int dir)
        {
            if (dir == 1)
            {
                
                if (LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W + 20 >= LLadder[0].X - DestX &&
                    LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W + 20 < LLadder[0].X + LLadder[0].W - DestX + 50)
                {
                    if (LMessage.Count == 0)
                    {
                        NearLadder = true;
                        ctLadder = 0;
                        CreateLadderMessage();
                    }
                }
                else
                {
                    NearLadder = false;
                    LMessage.Clear();
                }
                
                if (!HeroJumped)
                {
                    LHero[0].iFrame++;
                    if (LHero[0].iFrame > LHero[0].LAnimation[LHero[0].iAnimation].LFrame.Count - 1)
                    {
                        LHero[0].iFrame = 0;
                    }
                    if (DestX < 5880)
                    {
                        DestX += ScrollSpeed;
                    }
                    else
                    {
                        LHero[0].X += ScrollSpeed;
                    }
                }
                else
                {
                    if (DestX < 5880)
                    {
                        DestX += ScrollSpeed;
                        
                    }
                    else
                    {
                        LHero[0].X += ScrollSpeed;
                    }
                }
            }
            else
            {
                if (DestX > 0)
                {
                    if (LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W + 20 >= LLadder[0].X - DestX &&
                    LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W + 20 < LLadder[0].X + LLadder[0].W - DestX + 50)
                    {
                        if (LMessage.Count == 0)
                        {
                            NearLadder = true;
                            ctLadder = 0;
                            CreateLadderMessage();
                        }
                    }
                    else
                    {
                        NearLadder = false;
                        LMessage.Clear();
                    }

                    if (!HeroJumped)
                    {
                        LHero[0].iFrame--;
                        if (LHero[0].iFrame < 0)
                        {
                            LHero[0].iFrame = LHero[0].LAnimation[LHero[0].iAnimation].LFrame.Count - 1;
                        }
                        if (DestX < 5880)
                        {
                            DestX -= ScrollSpeed;
                        }
                        else
                        {
                            LHero[0].X -= ScrollSpeed;
                        }
                    }
                    else
                    {
                        if (DestX < 5880)
                        {
                            DestX -= ScrollSpeed;
                        }
                        else
                        {
                            LHero[0].X -= ScrollSpeed;
                        }
                    }
                }
            }

            
        }

        void JumpHero()
        {
            if (!FreezeJump)
            {
                LHero[0].iFrame++;
            }

            if (LHero[0].iFrame > NHeroJump - 1)
            {
                LHero[0].iAnimation = 0;
                LHero[0].iFrame = 0;
                LHero[0].Y += 50;
                LHero[0].X += 20;
                HeroJumped = false;
                HeroDoubleJumped = false;
                DoubleJumpTime = false;
                if(SaveSpeedAfterJump)
                {
                    HeroSpeeded = true;
                    SaveSpeedAfterJump = false;
                }
            }
            if(LHero[0].iFrame == 7)
            {
                FreezeJump = true;
                DoubleJumpTime = true;
            }
            if(FreezeJump)
            {
                
                LHero[0].Y -= VJump;
                if (LLaser.Count > 0)
                {
                    LLaser[0].Y -= VJump;
                }
                if (HeroDoubleJumped)
                {
                    VJump -= 40;
                }
                else
                {
                    VJump -= 10;
                }

                if (VJump <= 0)
                {
                    if (HeroDoubleJumped)
                    {
                        VJump = 120;
                    }
                    else
                    {
                        VJump = 50;
                    }
                    FreezeJump = false;
                }
            }
             if(LHero[0].iFrame > 7 && LHero[0].iFrame < 10)
             {
                DoubleJumpTime = false;
                if (DestX > 380 && DestX < 850)
                {
                    LHero[0].Y += (LHeroTreeBranch[0].Y) - (LHero[0].Y + LHero[0].LAnimation[LHero[0].iAnimation].H) + 70;
                }
                else if(DestX > 1250 && DestX < 1500)
                {
                    LHero[0].Y += (LGroundTree[0].Y) - (LHero[0].Y + LHero[0].LAnimation[LHero[0].iAnimation].H);
                }
                else
                {
                    LHero[0].Y += (this.ClientSize.Height - 20) - (LHero[0].Y + LHero[0].LAnimation[LHero[0].iAnimation].H);
                }

                if (LLaser.Count > 0)
                {
                    LLaser[0].Y += VJump;
                }
                if (HeroDoubleJumped)
                {
                    VJump += 140;
                }
                else
                {
                    VJump += 50;
                }

                //VJump += (this.ClientSize.Height - 50) - (LHero[0].Y +  LHero[0].LAnimation[LHero[0].iAnimation].H);
            }
        }

        void RunHero()
        {
            if (ctDClick > 5)
            {
                HeroSpeeded = false;
                ctDClick = 0;
                DClick = 0;
                ScrollSpeed = 6;
                LHero[0].iAnimation = 0;
                vDClick = 1;
            }
        }

        void CreateLaser()
        {
            Laser pnn = new Laser();
            pnn.X = LHero[0].X + LHero[0].LAnimation[0].W - 60;
            pnn.Y = LHero[0].Y + 26;
            pnn.W = 200;
            pnn.H = 6;
            pnn.colors = new List<Bitmap>();
            pnn.colorNo = -1;
            for (int i = 1; i <= Lasers; i++)
            {
                pnn.colors.Add(new Bitmap("Lasers\\Laser" + i + ".png"));
            }
            LLaser.Add(pnn);
            
        }

        void DoLaser()
        {
            if (!HeroCrawled)
            {
                if (HeroSpeeded)
                {
                    LLaser[0].X = LHero[0].X + LHero[0].LAnimation[0].W - 45;
                }
                else
                {
                    LLaser[0].X = LHero[0].X + LHero[0].LAnimation[0].W - 60;
                }
                LBars[2].Progress[0].W -= 2;
                
                if (LLaser[0].X + LLaser[0].W <= this.ClientSize.Width - 140)
                {
                    LLaser[0].W += 140;
                }
                if (LBars[2].Progress[0].W <= 0)
                {
                    LLaser.Clear();
                    LaserCharged = false;
                    LaserEnabled = false;
                }
                CheckEnemyDied();

            }
            else
            {
                LaserCharged = false;
                LaserEnabled = false;
                LLaser.Clear();
                RechargeLaser();
            }
        }

        void RechargeLaser()
        {
            LBars[2].Progress[0].W += 3;
            if(LBars[2].Progress[0].W >= LBars[2].W)
            {
                LaserCharged = true;
            }
        }

        void RechargedRun()
        {
            LBars[1].Progress[0].W += 3;
            if (LBars[1].Progress[0].W >= LBars[1].W)
            {
                RunCharged = true;
            }
        }

        void CreateArrow()
        {
            HeroArrow pnn = new HeroArrow();
            pnn.X = LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W - 70;
            pnn.Y = LHero[0].Y + 80;
            pnn.W = 150;
            pnn.H = 15;
            pnn.im = new Bitmap("Arrow\\ArrowBow.png");
            LHeroArrow.Add(pnn);
        }

        void MoveArrow()
        {
            if (LScopeLine.Count == 0 && !QueueStartScopeShot)
            {
                for (int i = 0; i < LHeroArrow.Count; i++)
                {
                    LHeroArrow[i].X += 100;

                    if (LHeroArrow[i].X + LHeroArrow[i].W >= this.ClientSize.Width - 120)
                    {
                        LHeroArrow.Remove(LHeroArrow[i]);
                    }
                }
            }
            else if(LScopeLine.Count > 0 && !QueueStartScopeShot)
            {
                for (int i = 0; i < LHeroArrow.Count; i++)
                {
                        LHeroArrow[i].X+= ArrowScopedSpeed;
                    

                    if (LScopeLine[0].Y2 < LHeroArrow[i].Y)
                    {
                        LHeroArrow[i].Y -= (LScopeLine[0].Y1 - LScopeLine[0].Y2) / LScopeLine[0].dScopeXd;              // <3 :D
                    }

                    if (LScopeLine[0].Y2 > LHeroArrow[i].Y)
                    {
                        LHeroArrow[i].Y += (LScopeLine[0].Y2 - LScopeLine[0].Y1) / LScopeLine[0].dScopeXd;              // <3 :D
                    }

                    if (LHeroArrow[i].X + LHeroArrow[i].W >= LScopeLine[0].X2 &&
                        LHeroArrow[i].Y <= LScopeLine[0].Y2)
                    {
                        LHeroArrow.Remove(LHeroArrow[i]);
                        LScopeLine.Clear();
                        break;
                    }
                }
            }
            
            if (QueueStartScopeShot)
            {
                
                if (LScopeImg.Count > 0)
                {
                    for (int i = 0; i < LHeroArrow.Count; i++)
                    {
                        ArrowScopeImginAir = true;

                            LHeroArrow[i].X+=ArrowScopedSpeed;

                        if (LScopeImg[i].Y + 35 < LHeroArrow[i].Y)
                        {
                            LHeroArrow[i].Y -= LScopeImg[i].dScopeY / LScopeImg[i].dScopeXd;              // <3 :D
                            //label2.Visible = true;
                            //label2.Text = "" + LHeroArrow[i].Y + "   " + LScopeImg[i].dScopeY + "   " + LScopeImg[i].dScopeXd + "   " + (LScopeImg[i].dScopeY / LScopeImg[i].dScopeXd);
                        }

                        if (LScopeImg[i].Y > LHeroArrow[i].Y)
                        {
                            LHeroArrow[i].Y += LScopeImg[i].dScopeY / LScopeImg[i].dScopeXd;              // <3 :D
                        }

                        if (LHeroArrow[i].X + LHeroArrow[i].W >= LScopeImg[i].X + 35 &&
                            LHeroArrow[i].Y <= LScopeImg[i].Y + 35)
                        {
                            LHeroArrow.Remove(LHeroArrow[i]);
                            ArrowScopeImginAir = false;
                            LScopeImg.Remove(LScopeImg[i]);
                            ctScopeImg--;
                            break;
                        }
                        
                    }
                }
            }
            
        }

        void HeroMShotAnimate()
        {
            LHero[0].iFrame++;
            if(LHero[0].iFrame >= NHeroShotM)
            {
                LHero[0].iFrame = 0;
                CreateArrow();
            }
        }

        void HeroSShotAnimate()
        {
            LHero[0].iFrame++;
            if (LHero[0].iFrame == 8)
            {
                CreateArrow();
            }
            if(LHero[0].iFrame >= NHeroShotS)
            {
                LHero[0].iFrame = 0;
                HeroStartShotS = false;
                LHero[0].Y += 50;
                LHero[0].X += 20;
                LHero[0].iAnimation = 0;
                LHero[0].iFrame = 0;
                HideScopeLine = true;
                
            }
        }

        void HeroSShotAnimate2()
        {
            LHero[0].iFrame++;
            if (LHero[0].iFrame == 8)
            {
                ctScopeImg++;
                CreateArrow();
            }
            if (LHero[0].iFrame >= NHeroShotS)
            {
                if (LScopeImg.Count == ctScopeImg && !ArrowScopeImginAir)
                {
                    LHero[0].iFrame = 0;
                    LHero[0].iAnimation = 0;
                    LHero[0].Y += 50;
                    LHero[0].X += 20;
                    QueueStartScopeShot = false;
                    LScopeImg.Clear();
                    ctScopeImg = 0;
                }
                LHero[0].iFrame = 0;
            }
        }

        void CreateScopeLine(int eX, int eY)
        {
            ScopeLine pnn = new ScopeLine();
            pnn.X1 = eX;
            pnn.Y1 = eY;
            pnn.X2 = eX;
            pnn.Y2 = eY;
            LScopeLine.Add(pnn);
        }

        void CreateScopeImg(int eX, int eY)
        {
            ScopeImg pnn = new ScopeImg();
            pnn.W = 70;
            pnn.H = 70;
            pnn.X = eX - 35;
            pnn.Y = eY - 35;
            pnn.im = new Bitmap("Scope\\Scope.png");
            pnn.dScopeX = pnn.X - (LHero[0].X + LHero[0].LAnimation[5].W - 70);
            pnn.dScopeXd = pnn.dScopeX / ArrowScopedSpeed;
            if (pnn.Y > LHero[0].Y + (80 - 50))
            {
                pnn.dScopeY = pnn.Y - (LHero[0].Y + (80 - 50));
            }
            else
            {
                pnn.dScopeY = (LHero[0].Y + (80 - 50)) - pnn.Y;
            }
            //MessageBox.Show("" + pnn.dScopeX + "  " + pnn.dScopeXd + "  " + pnn.dScopeY);
            LScopeImg.Add(pnn);
            
        }

        void CreateLadderMessage()
        {
            HeroMessage pnn = new HeroMessage();
            pnn.X = LHero[0].X + 50;
            pnn.Y = LHero[0].Y - 50;
            pnn.W = 140;
            pnn.H = 25;
            pnn.st = "Press u to climb";
            LMessage.Add(pnn);
        }

        void CreateHeroTreeBranch()
        {
            HeroTreeBranch pnn = new HeroTreeBranch();
            pnn.X = LLadder[0].X + LLadder[0].W;
            pnn.Y = LLadder[0].Y;
            pnn.W = 400;
            pnn.H = 200;
            pnn.im = new Bitmap("Trees\\HeroTree2.png");
            LHeroTreeBranch.Add(pnn);
        }

        void CreateGroundTree()
        {
            GroundTree pnn = new GroundTree();
            pnn.X = 1200;
            pnn.W = 600;
            pnn.H = 100;
            pnn.Y = this.ClientSize.Height - pnn.H - 20;
            pnn.im = new Bitmap("Trees\\GroundTree.png");
            LGroundTree.Add(pnn);
        }

        void CreateEnemyTree()
        {
            EnemyTree pnn = new EnemyTree();
            pnn.W = 400;
            pnn.H = 200;
            pnn.Y = this.ClientSize.Height / 2;
            pnn.X = this.ClientSize.Width - pnn.W + 240;
            pnn.im = new Bitmap("Trees\\EnemyTree.png");
            LEnemyTree.Add(pnn);
        }

        void CreateEnemy()
        {
            for (int i = 0; i < 1; i++)
            {
                EnemyRock pnn = new EnemyRock();
                pnn.X = LEnemyTree[0].X + 70;
                pnn.Y = LEnemyTree[0].Y - 160;
                pnn.W = 200;
                pnn.H = 200;
                pnn.Health = 100;
                pnn.Delay = 0;
                pnn.im = new List<Bitmap>();
                for (int j = 1; j <= NEnemyRock; j++)
                {
                    pnn.im.Add(new Bitmap("EnemyRock\\E" + j + ".png"));
                }
                LEnemyRock.Add(pnn);
            }

            for (int i = 0; i < 1; i++)
            {
                EnemyFlame pnn = new EnemyFlame();
                pnn.X = LGroundTree[0].X - 250;
                pnn.Y = this.ClientSize.Height - 250;
                pnn.W = 200;
                pnn.H = 230;
                pnn.Health = 200;
                pnn.Delay = 0;
                pnn.im = new List<Bitmap>();
                for (int j = 1; j <= NEnemyFire; j++)
                {
                    pnn.im.Add(new Bitmap("EnemyFire\\E" + j + ".png"));
                }
                LEnemyFlame.Add(pnn);
            }
        }

        void CreateRock()
        {
            Rock pnn = new Rock();
            pnn.X = LEnemyRock[0].X - DestX + 80;
            pnn.Y = LEnemyRock[0].Y;
            pnn.W = 30;
            pnn.H = 30;
            pnn.dRockX = pnn.X - LHero[0].X + (LHero[0].LAnimation[LHero[0].iAnimation].W / 2);
            pnn.dRockXd = pnn.dRockX / RockSpeed;
            if (pnn.Y < LHero[0].Y + (LHero[0].LAnimation[LHero[0].iAnimation].H / 2))
            {
                pnn.dRockY = (LHero[0].Y + (LHero[0].LAnimation[LHero[0].iAnimation].H / 2)) - pnn.Y;
            }
            else
            {
                pnn.dRockY = pnn.Y - (LHero[0].Y + (LHero[0].LAnimation[LHero[0].iAnimation].H / 2));
            }
            pnn.im = new Bitmap("Rocks\\Rock.png");
            LRock.Add(pnn);
        }

        void MoveRock()
        {
            for(int i = 0; i < LRock.Count; i++)
            {
                LRock[i].X -= RockSpeed;
                LRock[i].Y += LRock[i].dRockY / LRock[i].dRockXd;
                if(LRock[i].X < LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W && LRock[i].X > LHero[0].X
                    && LRock[i].Y > LHero[0].Y && LRock[i].Y < LHero[0].Y + LHero[0].LAnimation[LHero[0].iAnimation].H)
                {
                    LBars[0].Progress[0].W -= 5;
                    
                    if(LBars[0].Progress[0].W <= 0)
                    {
                        Lose = true;
                    }
                    LRock.Remove(LRock[i]);
                }
                else
                {
                    if(LRock[i].X - DestX < 0 || LRock[i].Y > this.ClientSize.Height)
                    {
                        LRock.Remove(LRock[i]); ;
                    }
                }
            }
        }

        void CreateFlame()
        {
            Flame pnn = new Flame();
            pnn.X = LEnemyFlame[0].X + 20;
            pnn.Y = LEnemyFlame[0].Y + 15;
            pnn.W = 80;
            pnn.H = 50;
            pnn.im = new Bitmap("Flames\\Flame.png");
            LFlame.Add(pnn);
        }

        void MoveFlame()
        {
            for (int i = 0; i < LFlame.Count; i++)
            {
                LFlame[i].X -= FlameSpeed;
                if (LFlame[i].X < LHero[0].X + LHero[0].LAnimation[LHero[0].iAnimation].W && LFlame[i].X > LHero[0].X
                    && LFlame[i].Y > LHero[0].Y && LFlame[i].Y < LHero[0].Y + 50)
                {
                    LBars[0].Progress[0].W -= 15;

                    if (LBars[0].Progress[0].W <= 0)
                    {
                        Lose = true;
                    }
                    LFlame.Remove(LFlame[i]);
                }
                else
                {
                    if(LFlame[i].X - DestX < 0)
                    {
                        LFlame.Remove(LFlame[i]);
                    }
                }
            }
        }

        void CheckEnemyDied()
        {
            if (DestX > 0)
            {
                if (LHeroArrow.Count > 0)
                {
                    for (int i = 0; i < LEnemyRock.Count; i++)
                    {
                        for (int j = 0; j < LHeroArrow.Count; j++)
                        {
                            if (LHeroArrow[j].X + LHeroArrow[j].W >= LEnemyRock[i].X - DestX && LHeroArrow[j].X + LHeroArrow[j].W < LEnemyRock[i].X + LEnemyRock[i].W - DestX
                                && LHeroArrow[j].Y > LEnemyRock[i].Y && LHeroArrow[j].Y < LEnemyRock[i].Y + LEnemyRock[i].H)
                            {
                                LScore[0].amount += 20;
                                LScore[0].clr = Color.Blue;
                                LEnemyRock[i].Health -= 25;
                                LHeroArrow.Remove(LHeroArrow[j]);
                                LScopeLine.Clear();
                                if (LEnemyRock[i].Health <= 0)
                                {
                                    LEnemyRock.Remove(LEnemyRock[i]);
                                    EnemyRockDied = true;
                                }
                            }
                            else
                            {
                                LScore[0].clr = Color.White;
                            }
                        }
                    }

                    for (int i = 0; i < LEnemyFlame.Count; i++)
                    {
                        for (int j = 0; j < LHeroArrow.Count; j++)
                        {
                            if (LHeroArrow[j].X + LHeroArrow[j].W >= LEnemyFlame[i].X - DestX && LHeroArrow[j].X + LHeroArrow[j].W < LEnemyFlame[i].X + LEnemyFlame[i].W - DestX
                                && LHeroArrow[j].Y > LEnemyFlame[i].Y && LHeroArrow[j].Y < LEnemyFlame[i].Y + LEnemyFlame[i].H)
                            {
                                LScore[0].amount += 20;
                                LScore[0].clr = Color.Blue;
                                LEnemyFlame[i].Health -= 25;
                                LHeroArrow.Remove(LHeroArrow[j]);
                                LScopeLine.Clear();
                                if (LEnemyFlame[i].Health <= 0)
                                {
                                    LEnemyFlame.Remove(LEnemyFlame[i]);
                                    EnemyFlameDied = true;
                                }
                            }
                            else
                            {
                                LScore[0].clr = Color.White;
                            }
                        }
                    }
                }

                if (LaserEnabled)
                {
                    for (int i = 0; i < LEnemyRock.Count; i++)
                    {
                        if (LLaser[0].X + LLaser[0].W > LEnemyRock[i].X - DestX && LLaser[0].X < LEnemyRock[i].X + LEnemyRock[i].W - DestX
                                && LLaser[0].Y > LEnemyRock[i].Y - 50 && LLaser[0].Y < LEnemyRock[i].Y + LEnemyRock[i].H)
                        {
                            LScore[0].amount += 5;
                            LScore[0].clr = Color.Blue;
                            if (LLaser[0].colorNo == 0)
                            {
                                LEnemyRock[i].Health -= 1;
                            }
                            else if (LLaser[0].colorNo == 1)
                            {
                                LEnemyRock[i].Health -= 5;
                            }
                            else if (LLaser[0].colorNo == 2)
                            {
                                LEnemyRock[i].Health -= 7;
                            }
                            else
                            {
                                LEnemyRock[i].Health -= 10;
                            }

                            if (LEnemyRock[i].Health <= 0)
                            {
                                LEnemyRock.Remove(LEnemyRock[i]);
                                EnemyRockDied = true;
                            }
                        }
                        else
                        {
                            LScore[0].clr = Color.White;
                        }
                    }

                    for (int i = 0; i < LEnemyFlame.Count; i++)
                    {
                        if (LLaser[0].X + LLaser[0].W > LEnemyFlame[i].X - DestX && LLaser[0].X < LEnemyFlame[i].X + LEnemyFlame[i].W - DestX
                                && LLaser[0].Y > LEnemyFlame[i].Y - 50 && LLaser[0].Y < LEnemyFlame[i].Y + LEnemyFlame[i].H)
                        {
                            LScore[0].amount += 5;
                            LScore[0].clr = Color.Blue;
                            if (LLaser[0].colorNo == 0)
                            {
                                LEnemyFlame[i].Health -= 1;
                            }
                            else if (LLaser[0].colorNo == 1)
                            {
                                LEnemyFlame[i].Health -= 5;
                            }
                            else if (LLaser[0].colorNo == 2)
                            {
                                LEnemyFlame[i].Health -= 7;
                            }
                            else
                            {
                                LEnemyFlame[i].Health -= 10;
                            }

                            if (LEnemyFlame[i].Health <= 0)
                            {
                                LEnemyFlame.Remove(LEnemyFlame[i]);
                                EnemyFlameDied = true;
                            }
                        }
                        else
                        {
                            LScore[0].clr = Color.White;
                        }
                    }
                }
            }
        }

        void CreateFly()
        {
            Fly pnn = new Fly();
            pnn.X = 2150;
            pnn.Y = this.ClientSize.Height - 170;
            pnn.W = 200;
            pnn.H = 150;
            pnn.im = new Bitmap("Flys\\Fly2.png");
            LFly.Add(pnn);
        }

        void CreateBridge()
        {
            Bridge pnn = new Bridge();
            pnn.X = 2200;
            pnn.Y = (this.ClientSize.Height / 2) - 200;
            pnn.W = 1600;
            pnn.H = 200;
            pnn.Delay = 0;
            pnn.Destroy = 0;
            pnn.im = new Bitmap("Bridges\\Bridge.png");
            LBridge.Add(pnn);
        }

        void CreateBoat()
        {
            Boat pnn = new Boat();
            pnn.X = 3900;
            pnn.W = 350;
            pnn.H = 120;
            pnn.Health = 20;
            pnn.Y = this.ClientSize.Height - pnn.H - 20;
            pnn.im = new Bitmap("Boats\\Boat.png");
            LBoat.Add(pnn);
        }

        void CreateRain()
        {
            Rain pnn = new Rain();
            RR = new Random();
            pnn.X = RR.Next(3750, 5500);
            pnn.Y = 0;
            pnn.W = 3;
            pnn.H = RR.Next(15, 20);
            LRain.Add(pnn);
        }

        void FallRain()
        {
            for(int i = 0; i < LRain.Count; i++)
            {
                LRain[i].Y += 200;
                if(LRain[i].Y > this.ClientSize.Height)
                {
                    LRain.Remove(LRain[i]);
                }
            }
        }

        void CreateLight()
        {
            Light pnn = new Light();
            pnn.X = pnn.X = RR.Next(3750, 4800);
            pnn.Y = 0;
            RR = new Random();
            pnn.im = new Bitmap("Lights\\Light" + RR.Next(1, 3) + ".png");
            LLight.Add(pnn);
        }

        void ShineLight()
        {

        }

        void CreateHeroAnother()
        {
            for (int i = 0; i < 1; i++)                  // Paddling
            {
                HAnimation pnn = new HAnimation();
                pnn.W = 200;
                pnn.H = 250;
                LHero[0].LAnimation.Add(pnn);
            }


            for (int i = 1; i <= NHeroPaddling; i++)
            {
                HFrame pnn = new HFrame();
                pnn.im = new Bitmap("HeroPaddling\\H" + i + ".png");
                LHero[0].LAnimation[7].LFrame.Add(pnn);
            }

            for (int i = 0; i < 1; i++)                  // Swim
            {
                HAnimation pnn = new HAnimation();
                pnn.W = 300;
                pnn.H = 200;
                LHero[0].LAnimation.Add(pnn);
            }


            for (int i = 1; i <= NHeroSwim; i++)
            {
                HFrame pnn = new HFrame();
                pnn.im = new Bitmap("HeroSwim\\InsideWaterStyle\\H" + i + ".png");
                LHero[0].LAnimation[8].LFrame.Add(pnn);
            }
        }

        void CreateShark()
        {
            
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);

            g.DrawImage(BG,
                new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height),                                                                // Dest - Screen
                new Rectangle(DestX, DestY, this.ClientSize.Width , this.ClientSize.Height),                                                       // Src - Image
                GraphicsUnit.Pixel);


            if (Start)
            {
                SolidBrush ButtonColor = new SolidBrush(LSP[1].clr);
                g.DrawString("Survivance", new Font("Gadugi", 56, FontStyle.Bold), Brushes.Black, LSP[0].X, LSP[0].Y);
                g.FillRectangle(ButtonColor, LSP[1].X, LSP[1].Y, LSP[1].W, LSP[1].H);
                g.DrawString("Start the game!", new Font("Gadugi", 18, FontStyle.Bold), Brushes.White, LSP[2].X, LSP[2].Y);
            }

            if (!Start || StartAnimation)
            {
                for (int i = 0; i < LLadder.Count; i++)
                {
                    g.DrawImage(LLadder[i].im, LLadder[i].X - DestX, LLadder[i].Y, LLadder[i].W, LLadder[i].H);
                }

                for(int i = 0; i < LHeroTreeBranch.Count; i++)
                {
                    g.DrawImage(LHeroTreeBranch[i].im, LHeroTreeBranch[i].X - DestX, LHeroTreeBranch[i].Y, LHeroTreeBranch[i].W, LHeroTreeBranch[i].H);
                }

                for(int i = 0; i < LGroundTree.Count; i++)
                {
                    g.DrawImage(LGroundTree[i].im, LGroundTree[i].X - DestX, LGroundTree[i].Y, LGroundTree[i].W, LGroundTree[i].H);
                }

                for(int i = 0; i < LEnemyTree.Count; i++)
                {
                    g.DrawImage(LEnemyTree[i].im, LEnemyTree[i].X - DestX, LEnemyTree[i].Y, LEnemyTree[i].W, LEnemyTree[i].H);
                }

                for (int i = 0; i < LEnemyRock.Count; i++)
                {
                    g.DrawImage(LEnemyRock[i].im[LEnemyRock[i].iFrame], LEnemyRock[i].X - DestX, LEnemyRock[i].Y, LEnemyRock[i].W, LEnemyRock[i].H);
                    g.DrawString("Health : " + LEnemyRock[i].Health, new Font("Gadugi", 14, FontStyle.Bold), Brushes.Red, LEnemyRock[i].X - DestX + 30, LEnemyRock[i].Y - 30);
                }

                for (int i = 0; i < LEnemyFlame.Count; i++)
                {
                    g.DrawImage(LEnemyFlame[i].im[LEnemyFlame[i].iFrame], LEnemyFlame[i].X - DestX, LEnemyFlame[i].Y, LEnemyFlame[i].W, LEnemyFlame[i].H);
                    g.DrawString("Health : " + LEnemyFlame[i].Health, new Font("Gadugi", 14, FontStyle.Bold), Brushes.Red, LEnemyFlame[i].X  - DestX + 30, LEnemyFlame[i].Y - 30);
                }

                for (int i = 0; i < LRock.Count; i++)
                {
                    g.DrawImage(LRock[i].im, LRock[i].X - DestX, LRock[i].Y, LRock[i].W, LRock[i].H);
                }

                for (int i = 0; i < LFlame.Count; i++)
                {
                    g.DrawImage(LFlame[i].im, LFlame[i].X - DestX, LFlame[i].Y, LFlame[i].W, LFlame[i].H);
                }


                for(int i = 0; i < LBridge.Count; i++)
                {
                    g.DrawImage(LBridge[i].im,
                                new Rectangle(LBridge[i].X - DestX + LBridge[i].Destroy, LBridge[i].Y, LBridge[i].W - LBridge[i].Destroy, LBridge[i].H),                                                                // Dest - Screen
                                new Rectangle(LBridge[i].Destroy, 0, LBridge[i].W - LBridge[i].Destroy, LBridge[i].H),                                                           // Src - Image
                                GraphicsUnit.Pixel);
                }

                for (int i = 0; i < LFly.Count; i++)
                {
                    g.DrawImage(LFly[i].im, LFly[i].X - DestX, LFly[i].Y, LFly[i].W, LFly[i].H);
                }

                for (int i = 0; i < LBoat.Count; i++)
                {
                    g.DrawImage(LBoat[i].im, LBoat[i].X - DestX, LBoat[i].Y, LBoat[i].W, LBoat[i].H);
                    g.DrawString("Boat Health : " + LBoat[i].Health, new Font("Gadugi", 14, FontStyle.Bold), Brushes.DeepSkyBlue, LBoat[i].X - DestX + 250, LBoat[i].Y - 30);
                }

                g.DrawImage(LHero[0].LAnimation[LHero[0].iAnimation].LFrame[LHero[0].iFrame].im,
                            LHero[0].X,
                            LHero[0].Y,
                            LHero[0].LAnimation[LHero[0].iAnimation].W,
                            LHero[0].LAnimation[LHero[0].iAnimation].H);
              

                for (int i = 0; i < LRain.Count; i++)
                {
                    g.FillRectangle(Brushes.SkyBlue, LRain[i].X - DestX, LRain[i].Y, LRain[i].W, LRain[i].H);
                }

                for (int i = 0; i < LLight.Count; i++)
                {
                    g.DrawImage(LLight[i].im, LLight[i].X - DestX, LLight[i].Y);
                }

                for (int i = 0; i < LBars.Count; i++)
                {
                    g.FillRectangle(Brushes.Black, LBars[i].X, LBars[i].Y, LBars[i].W, LBars[i].H);
                    
                    for (int j = 0; j < LBars[i].Progress.Count; j++)
                    {
                        SolidBrush Br = new SolidBrush(LBars[i].Progress[j].clr);
                        g.FillRectangle(Br, LBars[i].Progress[j].X, LBars[i].Progress[j].Y, LBars[i].Progress[j].W, LBars[i].Progress[j].H);
                        g.DrawString(LBars[i].name, new Font("Gadugi", 18, FontStyle.Bold), Br, LBars[i].X + LBars[i].W + 10, LBars[i].Y - (LBars[i].H / 2) + 3);
                    }
                }

                for (int i = 0; i <= PrisonDir && i < 4; i++)
                {
                    g.FillRectangle(Brushes.White, LPrison[i].X, LPrison[i].Y, LPrison[i].W, LPrison[i].H);
                }

                for(int i = 0; i < LLaser.Count; i++)
                {
                    //g.FillRectangle(Brushes.LimeGreen, LLaser[i].X, LLaser[i].Y, LLaser[i].W, LLaser[i].H);
                    g.DrawImage(LLaser[i].colors[LLaser[i].colorNo], LLaser[i].X, LLaser[i].Y, LLaser[i].W, LLaser[i].H);
                }

                for(int i = 0; i < LScore.Count; i++)
                {
                    SolidBrush Br = new SolidBrush(LScore[i].clr);
                    g.DrawString(LScore[i].st + LScore[i].amount, new Font("Gadugi", 18, FontStyle.Bold), Br, LScore[i].X, LScore[i].Y);
                }

                for(int i = 0; i < LHeroArrow.Count; i++)
                {
                    g.DrawImage(LHeroArrow[i].im, LHeroArrow[i].X, LHeroArrow[i].Y, LHeroArrow[i].W, LHeroArrow[i].H);
                }

                if (!HideScopeLine)
                {
                    Pen p = new Pen(Color.Black, 10);
                    for (int i = 0; i < LScopeLine.Count; i++)
                    {
                        g.DrawLine(p, LScopeLine[i].X1, LScopeLine[i].Y1, LScopeLine[i].X2, LScopeLine[i].Y2);
                    }
                }

                if (!HideScopeImg)
                {
                    for (int i = 0; i < LScopeImg.Count; i++)
                    {
                        g.DrawImage(LScopeImg[i].im, LScopeImg[i].X, LScopeImg[i].Y, LScopeImg[i].W, LScopeImg[i].H);
                    }
                }

                

                for(int i = 0; i < LMessage.Count; i++)
                {
                    g.FillRectangle(Brushes.White, LMessage[i].X, LMessage[i].Y, LMessage[i].W, LMessage[i].H);
                    g.DrawString(LMessage[i].st, new Font("Gadugi", 12, FontStyle.Bold), Brushes.Black, LMessage[i].X + 5, LMessage[i].Y);
                    
                }
            }
        }

        void DrawDouble(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }

       
    }
}
