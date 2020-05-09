using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace StorybrewScripts
{
    
    public class Geometry : StoryboardObjectGenerator
    {
//ОСНОВНЫЕ ПРЕДНАСТРОЙКИ
        [Configurable]
        public string Story = ">200|";

        [Configurable]
        public int AppearTime = 0; 

        public enum Smooth {Off, SmoothX2, SmoothX3, SmoothPropX2, SmoothPropX3}

        [Configurable]
        public Smooth Smoothed;

        [Configurable]
        public bool BackForeLayer = false;

        [Configurable]
        public bool CharacterLayer = false;

        [Configurable]
        public bool PlantsLayer = false;

        [Configurable]
        public bool GrassLayer = false;

        [Configurable]
        public bool DirtLayer = false;

        [Configurable]
        public bool ShadowLayer = false;
        

        [Configurable]
        public bool FromCorner = false;

        [Configurable]
        public int TotalHeight = 20;

        [Configurable]
        public int AddBlocks = 20;

        [Configurable]
        public int HSpriteVisible = 14;

        [Configurable]
        public int shift = -280;

        [Configurable]
        public int backAddHigh = 100;
        [Configurable]
        public int backShift = 100;
        [Configurable]
        public int foreShift = 300;
        
//ОБЛАКА
        [Configurable]
        public bool clouds = false;
        [Configurable]
        public string p_cloud0 = "";
        [Configurable]
        public string p_cloud1 = "";
        [Configurable]
        public string p_cloud2 = "";
        [Configurable]
        public int cloudCount = 50;
        [Configurable]
        public int cloudExistTimeMax = 15000;
        [Configurable]
        public int cloudRandomAddTime = 4000;
        [Configurable]
        public float cloudSizeMax = (float)0.5;
        [Configurable]
        public float cloudFadeMax = (float)0.7;
        [Configurable]
        public Vector2 foreCloudY = new Vector2(0, 100);
        [Configurable]
        public Vector2 backCloudY = new Vector2(100, 300);

//ПЕРСОНАЖИ
        [Configurable]
        public double charSize = 0.5;
        [Configurable]
        public string Ap_char = "";
        [Configurable]
        public int AcharFCount = 0;
        [Configurable]
        public int AcharFDelay = 0;
        [Configurable]
        public int AcharBlockPos = 31;

        [Configurable]
        public string Bp_char = "";
        [Configurable]
        public int BcharFCount = 0;
        [Configurable]
        public int BcharFDelay = 0;
        [Configurable]
        public int BcharBlockPos = 31;

        [Configurable]
        public string Cp_char = "";
        [Configurable]
        public int CcharFCount = 0;
        [Configurable]
        public int CcharFDelay = 0;
        [Configurable]
        public int CcharBlockPos = 31;

        

//КОНФИГУРАЦИЯ БИОМ1
        [Configurable]
        public string Ap_sky = "";

        [Configurable]
        public string Ap_back = "";
        [Configurable]
        public string Ap_fore = "";

        [Configurable]
        public string Ap_rain = "";

        [Configurable]
        public string Ap_grass0 = "";
        [Configurable]
        public string Ap_grass1 = "";
        [Configurable]
        public string Ap_grass2 = "";

        [Configurable]
        public string Ap_dirt0 = "";
        [Configurable]
        public string Ap_dirt1 = "";
        [Configurable]
        public string Ap_dirt2 = "";

        [Configurable]
        public string Ap_tree0 = "";
        [Configurable]
        public string Ap_tree1 = "";
        [Configurable]
        public string Ap_tree2 = "";

        [Configurable]
        public string Ap_plant0 = "";
        [Configurable]
        public string Ap_plant1 = "";
        [Configurable]
        public string Ap_plant2 = "";

        [Configurable]
        public string Ap_shadow = "";

        [Configurable]
        public int ASectorChangeHeight = 6;
        [Configurable]
        public int AHeightGeneration = 14;
        [Configurable]
        public int AToRandom = 1500;
        [Configurable]
        public int ASolidLayers = 5;
        [Configurable]
        public int APlantGeneration = 6;
        [Configurable]
        public int ADistBetweenPlants = 10;
        [Configurable]
        public Color4 ASkyColor = new Color4(1, 1, 1, 1);
        [Configurable]
        public Color4 ASkyGColor = new Color4(0, 0, 0, 1);
        [Configurable]
        public Color4 AShadowColor = new Color4(0, 0, 0, 1);
        [Configurable]
        public int ADropCount = 350;
        [Configurable]
        public int ADropExistTime = 200;




//КОНФИГУРАЦИЯ БИОМ2
        [Configurable]
        public string Bp_sky = "";

        [Configurable]
        public string Bp_back = "";
        [Configurable]
        public string Bp_fore = "";

        [Configurable]
        public string Bp_rain = "";

        [Configurable]
        public string Bp_grass0 = "";
        [Configurable]
        public string Bp_grass1 = "";
        [Configurable]
        public string Bp_grass2 = "";

        [Configurable]
        public string Bp_dirt0 = "";
        [Configurable]
        public string Bp_dirt1 = "";
        [Configurable]
        public string Bp_dirt2 = "";

        [Configurable]
        public string Bp_tree0 = "";
        [Configurable]
        public string Bp_tree1 = "";
        [Configurable]
        public string Bp_tree2 = "";

        [Configurable]
        public string Bp_plant0 = "";
        [Configurable]
        public string Bp_plant1 = "";
        [Configurable]
        public string Bp_plant2 = "";

        [Configurable]
        public string Bp_shadow = "";

        [Configurable]
        public int BSectorChangeHeight = 6;
        [Configurable]
        public int BHeightGeneration = 14;
        [Configurable]
        public int BToRandom = 1500;
        [Configurable]
        public int BSolidLayers = 5;
        [Configurable]
        public int BPlantGeneration = 6;
        [Configurable]
        public int BDistBetweenPlants = 10;
        [Configurable]
        public Color4 BSkyColor = new Color4(1, 1, 1, 1);
        [Configurable]
        public Color4 BSkyGColor = new Color4(0, 0, 0, 1);
        [Configurable]
        public Color4 BShadowColor = new Color4(0, 0, 0, 1);
        [Configurable]
        public int BDropCount = 350;
        [Configurable]
        public int BDropExistTime = 200;

//КОНФИГУРАЦИЯ БИОМ3
        [Configurable]
        public string Cp_sky = "";

        [Configurable]
        public string Cp_back = "";
        [Configurable]
        public string Cp_fore = "";

        [Configurable]
        public string Cp_rain = "";

        [Configurable]
        public string Cp_grass0 = "";
        [Configurable]
        public string Cp_grass1 = "";
        [Configurable]
        public string Cp_grass2 = "";

        [Configurable]
        public string Cp_dirt0 = "";
        [Configurable]
        public string Cp_dirt1 = "";
        [Configurable]
        public string Cp_dirt2 = "";

        [Configurable]
        public string Cp_tree0 = "";
        [Configurable]
        public string Cp_tree1 = "";
        [Configurable]
        public string Cp_tree2 = "";

        [Configurable]
        public string Cp_plant0 = "";
        [Configurable]
        public string Cp_plant1 = "";
        [Configurable]
        public string Cp_plant2 = "";

        [Configurable]
        public string Cp_shadow = "";

        [Configurable]
        public int CSectorChangeHeight = 6;
        [Configurable]
        public int CHeightGeneration = 14;
        [Configurable]
        public int CToRandom = 1500;
        [Configurable]
        public int CSolidLayers = 5;
        [Configurable]
        public int CPlantGeneration = 6;
        [Configurable]
        public int CDistBetweenPlants = 10;
        [Configurable]
        public Color4 CSkyColor = new Color4(1, 1, 1, 1);
        [Configurable]
        public Color4 CSkyGColor = new Color4(0, 0, 0, 1);
        [Configurable]
        public Color4 CShadowColor = new Color4(0, 0, 0, 1);
        [Configurable]
        public int CDropCount = 350;
        [Configurable]
        public int CDropExistTime = 200;

//ИНИЦИАЛИЗАЦИЯ ПЕРЕМЕННЫХ
        public bool firstFloor = false;
        public int StartTime;
        public int EndTime = 0;

        public string p_sky = "";
        public string p_back = "";
        public string p_fore = "";

        public string p_rain = "";

        public string p_grass0 = "";
        public string p_grass1 = "";
        public string p_grass2 = "";

        public string p_dirt0 = "";
        public string p_dirt1 = "";
        public string p_dirt2 = "";

        public string p_tree0 = "";
        public string p_tree1 = "";
        public string p_tree2 = "";

        public string p_plant0 = "";
        public string p_plant1 = "";
        public string p_plant2 = "";

        public string p_shadow = "";

        public int SectorChangeHeight = 6;
        public int HeightGeneration = 14;
        public int ToRandom = 1500;
        public int SolidLayers = 5;
        public int PlantGeneration = 6;
        public int DistBetweenPlants = 10;
        public Color4 SkyColor = new Color4(255, 255, 255, 255);
        public Color4 SkyGColor = new Color4(255, 255, 255, 255);
        public Color4 ShadowColor = new Color4(255, 255, 255, 255);
        public int DropCount = 350;
        public int DropExistTime = 200;
        

//ПРИСВОЕНИЕ ПУТЕЙ ДЛЯ СПРАЙТОВ БИОМОВ
        public void biomeA(){
            p_sky = Ap_sky;

            p_back = Ap_back;
            p_fore = Ap_fore;
            p_rain = Ap_rain;

            p_grass0 = Ap_grass0;
            p_grass1 = Ap_grass1;
            p_grass2 = Ap_grass2;

            p_dirt0 = Ap_dirt0;
            p_dirt1 = Ap_dirt1;
            p_dirt2 = Ap_dirt2;

            p_tree0 = Ap_tree0;
            p_tree1 = Ap_tree1;
            p_tree2 = Ap_tree2;

            p_plant0 = Ap_plant0;
            p_plant1 = Ap_plant1;
            p_plant2 = Ap_plant2;

            p_shadow = Ap_shadow;

            SectorChangeHeight = ASectorChangeHeight;
            HeightGeneration = AHeightGeneration;
            ToRandom = AToRandom;
            SolidLayers = ASolidLayers;
            PlantGeneration = APlantGeneration;
            DistBetweenPlants = ADistBetweenPlants;
            SkyColor = ASkyColor;
            SkyGColor = ASkyGColor;
            ShadowColor = AShadowColor;
            DropCount = ADropCount;
            DropExistTime = ADropExistTime;
        }   

        public void biomeB(){
            p_sky = Bp_sky;

            p_back = Bp_back;
            p_fore = Bp_fore;
            p_rain = Bp_rain;

            p_grass0 = Bp_grass0;
            p_grass1 = Bp_grass1;
            p_grass2 = Bp_grass2;

            p_dirt0 = Bp_dirt0;
            p_dirt1 = Bp_dirt1;
            p_dirt2 = Bp_dirt2;

            p_tree0 = Bp_tree0;
            p_tree1 = Bp_tree1;
            p_tree2 = Bp_tree2;

            p_plant0 = Bp_plant0;
            p_plant1 = Bp_plant1;
            p_plant2 = Bp_plant2;

            p_shadow = Bp_shadow;

            SectorChangeHeight = BSectorChangeHeight;
            HeightGeneration = BHeightGeneration;
            ToRandom = BToRandom;
            SolidLayers = BSolidLayers;
            PlantGeneration = BPlantGeneration;
            DistBetweenPlants = BDistBetweenPlants;
            SkyColor = BSkyColor;
            SkyGColor = BSkyGColor;
            ShadowColor = BShadowColor;
            DropCount = BDropCount;
            DropExistTime = BDropExistTime;
        }   

        public void biomeC(){
            p_sky = Cp_sky;

            p_back = Cp_back;
            p_fore = Cp_fore;
            p_rain = Cp_rain;

            p_grass0 = Cp_grass0;
            p_grass1 = Cp_grass1;
            p_grass2 = Cp_grass2;

            p_dirt0 = Cp_dirt0;
            p_dirt1 = Cp_dirt1;
            p_dirt2 = Cp_dirt2;

            p_tree0 = Cp_tree0;
            p_tree1 = Cp_tree1;
            p_tree2 = Cp_tree2;

            p_plant0 = Cp_plant0;
            p_plant1 = Cp_plant1;
            p_plant2 = Cp_plant2;

            p_shadow = Cp_shadow;

            SectorChangeHeight = CSectorChangeHeight;
            HeightGeneration = CHeightGeneration;
            ToRandom = CToRandom;
            SolidLayers = CSolidLayers;
            PlantGeneration = CPlantGeneration;
            DistBetweenPlants = CDistBetweenPlants;
            SkyColor = CSkyColor;
            SkyGColor = CSkyGColor;;
            ShadowColor = CShadowColor;
            DropCount = CDropCount;
            DropExistTime = CDropExistTime;
        }   

//ОСНОВНАЯ ФУНКЦИЯ
        public override void Generate()
        {
            StartTime = AppearTime;
            
            char[] StoryArray = Story.ToCharArray();
            int countS = 0;
            int countAll = 0;

            string ETime = "";
            Color4 PrevSkyColor = SkyColor;
            Color4 PrevSkyGColor = SkyGColor;
            Color4 PrevShadowColor = ShadowColor;

            for(int j = 0; j < Story.Length; j++)
                if(StoryArray[j] == '>' || StoryArray[j] == '<' || StoryArray[j] == '|')
                    countAll++;

            for(int j = 0; j < Story.Length; j++)
            {
                int[,] BlockNExist = new int[HeightGeneration,(854 / HSpriteVisible) + AddBlocks + 1];
                int i;
                
                //1500A<1500B<1500C<1500B<1500C<1500B<1500A<
                if(StoryArray[j] == '>' || StoryArray[j] == '<' || StoryArray[j] == '|')
                    countS++;

                if(StoryArray[j] == 'A' && ETime != "")
                {
                    PrevSkyColor = SkyColor;
                    PrevSkyGColor = SkyGColor;
                    PrevShadowColor = ShadowColor;
                    biomeA();
                }
                if(StoryArray[j] == 'B' && ETime != "")
                {
                    PrevSkyColor = SkyColor;
                    PrevSkyGColor = SkyGColor;
                    PrevShadowColor = ShadowColor;
                    biomeB();
                }

                if(StoryArray[j] == 'C' && ETime != "")
                {
                    PrevSkyColor = SkyColor;
                    PrevSkyGColor = SkyGColor;
                    PrevShadowColor = ShadowColor;
                    biomeC();
                }
                
                if(StoryArray[j] == '>' && ETime != "")
                {
                    if(BackForeLayer)
                        SkyShadow(countS, PrevSkyColor, PrevSkyGColor, PrevShadowColor, "right", countAll);

                    for(i = 1; i <= HeightGeneration-1; i++)
                    {
                        if(DirtLayer)
                            BlockNExist = layer("DirtLayer", p_dirt0, p_dirt1, p_dirt2, 480 - (i*HSpriteVisible), BlockNExist, i, "right"); 
                        if(i == SolidLayers)
                            firstFloor = true;
                    }
                    if(PlantsLayer)
                    {
                        plantsLayer("PlantsLayer", p_plant0, p_plant1, p_plant2, BlockNExist, i, "right", true, OsbOrigin.BottomCentre); 
                        plantsLayer("PlantsLayer", p_tree0, p_tree1, p_tree2, BlockNExist, i, "right", true, OsbOrigin.Centre); 
                    }
                    if(GrassLayer)
                        grassLayer("GrassLayer", p_grass0, p_grass1, p_grass2, BlockNExist, i, "right"); 
                    
                    if(CharacterLayer)
                    {
                        if(Ap_char != "")
                            characterLayer("CharacterLayer", BlockNExist, i, "right", countS, Ap_char, AcharBlockPos, AcharFCount, AcharFDelay);
                        if(Bp_char != "")
                            characterLayer("CharacterLayer", BlockNExist, i, "right", countS, Bp_char, BcharBlockPos, BcharFCount, BcharFDelay);
                        if(Cp_char != "")
                            characterLayer("CharacterLayer", BlockNExist, i, "right", countS, Cp_char, CcharBlockPos, CcharFCount, CcharFDelay);
                    }

                    ETime = "";
                    
                    //StartTime = (EndTime * HSpriteVisible) / Math.Abs(shift) * ((854/HSpriteVisible) + AddBlocks + 1);
                    StartTime = AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * (AddBlocks + 1))*countS);
                    firstFloor = false;
                    FromCorner = true;
                    for (int l1 = 0; l1 < HeightGeneration; l1++)
                        for(int l2 = 0; l2 < (854 / HSpriteVisible) + AddBlocks + 1; l2++)
                            BlockNExist[l1, l2] = 0;
                    

                }
                if(StoryArray[j] == '<' && ETime != "")
                {
                    if(BackForeLayer)
                        SkyShadow(countS, PrevSkyColor, PrevSkyGColor, PrevShadowColor, "left", countAll);   

                    for(i = 1; i <= HeightGeneration-1; i++)
                    {
                        if(DirtLayer)
                            BlockNExist = layer("DirtLayer", p_dirt0, p_dirt1, p_dirt2, 480 - (i*HSpriteVisible), BlockNExist, i, "left"); 
                        if(i == SolidLayers)
                            firstFloor = true;
                    }
                    if(PlantsLayer)
                    {
                        plantsLayer("PlantsLayer", p_plant0, p_plant1, p_plant2, BlockNExist, i, "left", true, OsbOrigin.BottomCentre); 
                        plantsLayer("PlantsLayer", p_tree0, p_tree1, p_tree2, BlockNExist, i, "left", true, OsbOrigin.Centre);
                    }
                    if(GrassLayer)
                        grassLayer("GrassLayer", p_grass0, p_grass1, p_grass2, BlockNExist, i, "left");  
                    
                    if(CharacterLayer)
                    {
                        if(Ap_char != "")
                            characterLayer("CharacterLayer", BlockNExist, i, "left", countS, Ap_char, AcharBlockPos, AcharFCount, AcharFDelay);
                        if(Bp_char != "")
                            characterLayer("CharacterLayer", BlockNExist, i, "left", countS, Bp_char, BcharBlockPos, BcharFCount, BcharFDelay);
                        if(Cp_char != "")
                            characterLayer("CharacterLayer", BlockNExist, i, "left", countS, Cp_char, CcharBlockPos, CcharFCount, CcharFDelay);
                    }
                    ETime = "";

                    StartTime = AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * (AddBlocks))*countS);
                    firstFloor = false;
                    FromCorner = true;
                    for (int l1 = 0; l1 < HeightGeneration; l1++)
                        for(int l2 = 0; l2 < (854 / HSpriteVisible) + AddBlocks + 1; l2++)
                            BlockNExist[l1, l2] = 0;
                }

                
                if(StoryArray[j] == '0' ||
                    StoryArray[j] == '1' ||
                    StoryArray[j] == '2' ||
                    StoryArray[j] == '3' ||
                    StoryArray[j] == '4' ||
                    StoryArray[j] == '5' ||
                    StoryArray[j] == '6' ||
                    StoryArray[j] == '7' ||
                    StoryArray[j] == '8' ||
                    StoryArray[j] == '9')
                {
                    ETime += StoryArray[j];
                }
                if(ETime != "")
                    EndTime = Int32.Parse(ETime);
            }
            
        }
//ОБЛАКА, ТЕНИ
        public void SkyShadow(int countS, Color4 PrevSkyColor, Color4 PrevSkyGColor, Color4 PrevShadowColor, string dir, int countA) {
            //sky
            var layerSky = GetLayer("SkyLayer");
            var bitmapSky = GetMapsetBitmap(p_sky);
            var spriteSky = layerSky.CreateSprite(p_sky, OsbOrigin.Centre);
            int addB = 0;
            if(dir == "right")
                addB = AddBlocks + 1;
            else addB = AddBlocks;
            spriteSky.Move(StartTime, AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), 320, 240, 320, 240);
            if(countS == 1)
                spriteSky.Color(StartTime, StartTime, SkyColor, SkyColor);
            else {
                spriteSky.Color(StartTime, StartTime + (EndTime + Math.Abs(shift))/2, PrevSkyColor, SkyColor);
                spriteSky.Color(StartTime + (EndTime + Math.Abs(shift))/2, AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), SkyColor, SkyColor);
            }
            spriteSky.ScaleVec(StartTime, StartTime, (float)854/bitmapSky.Width, (float)480/bitmapSky.Height, (float)854/bitmapSky.Width, (float)480/bitmapSky.Height);
            
            //SkyGradient
            // var bitmapSkyGradient = GetMapsetBitmap(p_shadow);
            // var spriteSkyGradient = layerSky.CreateSprite(p_shadow, OsbOrigin.Centre);

            // spriteSkyGradient.Move(StartTime, AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), 320, 240, 320, 240);
            // if(countS == 1)
            //     spriteSkyGradient.Color(StartTime, StartTime, SkyGColor, SkyGColor);
            // else {
            //     spriteSkyGradient.Color(StartTime, StartTime + (EndTime + Math.Abs(shift))/2, PrevSkyGColor, SkyGColor);
            //     spriteSkyGradient.Color(StartTime + (EndTime + Math.Abs(shift))/2, AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), SkyGColor, SkyGColor);
            // }
            // spriteSkyGradient.ScaleVec(StartTime, StartTime, (float)854/bitmapSkyGradient.Width, (float)480/bitmapSkyGradient.Height, (float)854/bitmapSkyGradient.Width, (float)480/bitmapSkyGradient.Height);
            
            //Clouds
            if(clouds)
            {
                var layerBackClouds = GetLayer("BackgroundCloudsLayer");
                for(int i = 0; i < cloudCount; i++)
                {
                    int cloudStart = Random(StartTime, AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS));
                    int cloudAddTime = Random(cloudRandomAddTime*4, cloudRandomAddTime*8);
                    int cloudRandomPath = Random(0,3);
                    double cloudRandomY = Random(backCloudY.X, backCloudY.Y);
                    string cloudPath = "";
                    double scaleStep = Math.Abs(0.4 - 0.05) / (float)backCloudY.Y;
                    double fadeStep = Math.Abs(0.7 - 0.5) / (float)backCloudY.Y;
                    switch(cloudRandomPath)
                    {
                        case 0: cloudPath = p_cloud0; break;
                        case 1: cloudPath = p_cloud1; break;
                        case 2: cloudPath = p_cloud2; break;
                    }
                    if(cloudStart + cloudExistTimeMax + cloudAddTime < AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countA))
                    {
                        var spriteCloud = layerBackClouds.CreateSprite(cloudPath, OsbOrigin.Centre);
                        var bitmapCloud = GetMapsetBitmap(cloudPath);
                        double cloudShift = bitmapCloud.Width * (cloudSizeMax - (cloudRandomY*scaleStep));
                        if(dir == "left")
                            spriteCloud.Move(cloudStart, cloudStart + cloudExistTimeMax + cloudAddTime, -107 - cloudShift, cloudRandomY, 747 + cloudShift, cloudRandomY);
                        else spriteCloud.Move(cloudStart, cloudStart + cloudExistTimeMax + cloudAddTime, 747 + cloudShift, cloudRandomY, -107 - cloudShift, cloudRandomY);
                        spriteCloud.Scale(cloudStart, cloudStart, 0.4 - (cloudRandomY*scaleStep), 0.4 - (cloudRandomY*scaleStep));
                        spriteCloud.Fade(cloudStart, cloudStart, 0.7 - (cloudRandomY*fadeStep), 0.7 - (cloudRandomY*fadeStep));
                        if(i % 2 == 0)
                            spriteCloud.FlipH(cloudStart, cloudStart);
                    }
                }
            }

            //SkyBackgroundImage
            var layerBack = GetLayer("BackgroundLayer");
            var bitmapBack = GetMapsetBitmap(p_back);
            var spriteBack0 = layerBack.CreateSprite(p_back, OsbOrigin.BottomCentre);
            spriteBack0.Move(StartTime, AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 320 - (bitmapBack.Width*0.7), 480 - (HSpriteVisible*SolidLayers) + backAddHigh, 320 - (bitmapBack.Width*0.7) + backShift, 480 - (HSpriteVisible*SolidLayers) + backAddHigh);
            spriteBack0.Scale(StartTime, StartTime, 0.7,0.7);
            spriteBack0.Color(StartTime, StartTime, SkyGColor, SkyGColor);
            if(countS != 1)
            {
                spriteBack0.Fade(StartTime, StartTime + (EndTime + Math.Abs(shift))/2, 0, 1);
                spriteBack0.Fade(AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 1, 0);
            }
            else spriteBack0.Fade(AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 1, 0);

            var spriteBack1 = layerBack.CreateSprite(p_back, OsbOrigin.BottomCentre);
            spriteBack1.Move(StartTime, AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 320, 480 - (HSpriteVisible*SolidLayers) + backAddHigh, 320 + backShift, 480 - (HSpriteVisible*SolidLayers) + backAddHigh);
            spriteBack1.Scale(StartTime, StartTime, 0.7,0.7);
            spriteBack1.Color(StartTime, StartTime, SkyGColor, SkyGColor);
            if(countS != 1)
            {
                spriteBack1.Fade(StartTime, StartTime + (EndTime + Math.Abs(shift))/2, 0, 1);
                spriteBack1.Fade(AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 1, 0);
            }
            else spriteBack1.Fade(AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 1, 0);

            var spriteBack2 = layerBack.CreateSprite(p_back, OsbOrigin.BottomCentre);
            spriteBack2.Move(StartTime, AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 320 + (bitmapBack.Width*0.7), 480 - (HSpriteVisible*SolidLayers) + backAddHigh, 320 + (bitmapBack.Width*0.7) + backShift, 480 - (HSpriteVisible*SolidLayers) + backAddHigh);
            spriteBack2.Scale(StartTime, StartTime, 0.7,0.7);
            spriteBack2.Color(StartTime, StartTime, SkyGColor, SkyGColor);
            if(countS != 1)
            {
                spriteBack2.Fade(StartTime, StartTime + (EndTime + Math.Abs(shift))/2, 0, 1);
                spriteBack2.Fade(AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 1, 0);
            }
            else spriteBack2.Fade(AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 1, 0);

            //SkyForegroundImage
            var layerFore = GetLayer("ForegroundLayer");
            var bitmapFore = GetMapsetBitmap(p_fore);
            var spriteFore0 = layerFore.CreateSprite(p_fore, OsbOrigin.BottomCentre);
            spriteFore0.Move(StartTime, AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 320 - (bitmapFore.Width*0.7), 480 - (HSpriteVisible*SolidLayers), 320 - (bitmapFore.Width*0.7) + foreShift, 480 - (HSpriteVisible*SolidLayers));
            spriteFore0.Scale(StartTime, StartTime, 0.7,0.7);
            spriteFore0.Color(StartTime, StartTime,0.7, 0.7, 0.7, 0.7, 0.7, 0.7);
            if(countS != 1)
            {
                spriteFore0.Fade(StartTime, StartTime + (EndTime + Math.Abs(shift))/2, 0, 1);
                spriteFore0.Fade(AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 1, 0);
            }
            else spriteFore0.Fade(AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 1, 0);

            var spriteFore1 = layerFore.CreateSprite(p_fore, OsbOrigin.BottomCentre);
            spriteFore1.Move(StartTime, AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 320, 480 - (HSpriteVisible*SolidLayers), 320 + foreShift, 480 - (HSpriteVisible*SolidLayers));
            spriteFore1.Scale(StartTime, StartTime, 0.7,0.7);
            spriteFore1.Color(StartTime, StartTime, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7);
            if(countS != 1)
            {
                spriteFore1.Fade(StartTime, StartTime + (EndTime + Math.Abs(shift))/2, 0, 1);
                spriteFore1.Fade(AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 1, 0);
            }
            else spriteFore1.Fade(AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 1, 0);

            var spriteFore2 = layerFore.CreateSprite(p_fore, OsbOrigin.BottomCentre);
            spriteFore2.Move(StartTime, AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 320 + (bitmapFore.Width*0.7), 480 - (HSpriteVisible*SolidLayers), 320 + (bitmapFore.Width*0.7) + foreShift, 480 - (HSpriteVisible*SolidLayers));
            spriteFore2.Scale(StartTime, StartTime, 0.7,0.7);
            spriteFore2.Color(StartTime, StartTime, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7);
            if(countS != 1)
            {
                spriteFore2.Fade(StartTime, StartTime + (EndTime + Math.Abs(shift))/2, 0, 1);
                spriteFore2.Fade(AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 1, 0);
            }
            else spriteFore2.Fade(AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS) + (EndTime + Math.Abs(shift))/2, 1, 0);

            //CloudsBackground
            if(clouds)
            {
                var layerForeClouds = GetLayer("ForegroundCloudsLayer");
                for(int i = 0; i < cloudCount; i++)
                {
                    int cloudStart = Random(StartTime, AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS));
                    int cloudAddTime = Random(0, cloudRandomAddTime);
                    int cloudRandomPath = Random(0,3);
                    double cloudRandomY = Random(foreCloudY.X, foreCloudY.Y);
                    string cloudPath = "";
                    double scaleStep = Math.Abs(cloudSizeMax - 0.25) / (float)foreCloudY.Y;
                    double fadeStep = Math.Abs(cloudFadeMax - 0.85) / (float)foreCloudY.Y;
                    switch(cloudRandomPath)
                    {
                        case 0: cloudPath = p_cloud0; break;
                        case 1: cloudPath = p_cloud1; break;
                        case 2: cloudPath = p_cloud2; break;
                    }
                    if(cloudStart + cloudExistTimeMax + cloudAddTime < AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countA))
                    {
                        var spriteCloud = layerForeClouds.CreateSprite(cloudPath, OsbOrigin.Centre);
                        var bitmapCloud = GetMapsetBitmap(cloudPath);
                        double cloudShift = bitmapCloud.Width * (cloudSizeMax - (cloudRandomY*scaleStep));
                        if(dir == "left")
                            spriteCloud.Move(cloudStart, cloudStart + cloudExistTimeMax + cloudAddTime, -107 - cloudShift, cloudRandomY, 747 + cloudShift, cloudRandomY);
                        else spriteCloud.Move(cloudStart, cloudStart + cloudExistTimeMax + cloudAddTime, 747 + cloudShift, cloudRandomY, -107 - cloudShift, cloudRandomY);
                        spriteCloud.Scale(cloudStart, cloudStart, cloudSizeMax - (cloudRandomY*scaleStep), cloudSizeMax - (cloudRandomY*scaleStep));
                        spriteCloud.Fade(cloudStart, cloudStart, cloudFadeMax - (cloudRandomY*fadeStep), cloudFadeMax - (cloudRandomY*fadeStep));
                        if(i % 2 == 0)
                            spriteCloud.FlipH(cloudStart, cloudStart);
                    }
                }
            }

            if(p_rain != "")
            {
                var layerRain = GetLayer("RainLayer");
                for(int i = 0; i < DropCount; i++)
                {
                    var spriteDrop = layerRain.CreateSprite(p_rain, OsbOrigin.Centre);
                    int dropStart = Random(StartTime, AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS));
                    int randomStartX = Random(-107, 747);
                    if(dir == "left")
                    {
                        spriteDrop.Move(dropStart, dropStart + DropExistTime, randomStartX, 0, randomStartX + (EndTime*HSpriteVisible)/Math.Abs(shift)/2, 480 - (HSpriteVisible*SolidLayers));
                        spriteDrop.Rotate(dropStart, dropStart, -0.1, -0.1);
                    }
                    else {
                        spriteDrop.Move(dropStart, dropStart + DropExistTime, randomStartX, 0, randomStartX - (EndTime*HSpriteVisible)/Math.Abs(shift)/2, 480 - (HSpriteVisible*SolidLayers));
                        spriteDrop.Rotate(dropStart, dropStart, 0.1,0.1);
                    }
                }
            }

            //Shadow
            if(ShadowLayer)
            {
                var layerShadow = GetLayer("ShadowLayer");
                var bitmapShadow = GetMapsetBitmap(p_shadow);
                var spriteShadow = layerShadow.CreateSprite(p_shadow, OsbOrigin.BottomCentre);

                spriteShadow.Move(StartTime, AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), 320, 480, 320, 480);
                if(countS == 1)
                    spriteShadow.Color(StartTime, StartTime, ShadowColor, ShadowColor);
                else {
                    spriteShadow.Color(StartTime, StartTime + (EndTime + Math.Abs(shift))/2, PrevShadowColor, ShadowColor);
                    spriteShadow.Color(StartTime + (EndTime + Math.Abs(shift))/2, AppearTime + (((EndTime*HSpriteVisible)/Math.Abs(shift) * addB)*countS), ShadowColor, ShadowColor);
                }
                spriteShadow.ScaleVec(StartTime, StartTime, (float)854/bitmapShadow.Height, (float)(SolidLayers * HSpriteVisible) / bitmapShadow.Height, (float)854/bitmapShadow.Height, (float)(SolidLayers * HSpriteVisible) / bitmapShadow.Height);
            }
        }
//ПЕРСОНАЖ

        public void characterLayer(string currlayer, int[,] prevBlockArray, int floorID, string dir, int countS, string p_char, int charBlockPos, int charFCount, int charFDelay)
        {
            var layer = GetLayer(currlayer);
            int[] BlockHeight = new int[(854 / HSpriteVisible) + AddBlocks + 1];
            
            int flatZone = 10;
            for(int j = 0; j <= (854 / HSpriteVisible) + AddBlocks; j++)
            {
                if((Randomed[j] < 50) && (Randomed[j] > 20) && (flatZone <= 0))
                    flatZone = 10;
                if((Randomed[j] < 20) && (flatZone <= 0))
                    flatZone = 15;

                for(int i = 1; i <= HeightGeneration - 1; i ++)
                {
                    if(prevBlockArray[i, j] == 1)
                    {
                        if(flatZone <= 0)
                            BlockHeight[j] ++;
                        else{
                            if(flatZone > 10)
                                BlockHeight[j] = 15;
                            else
                                BlockHeight[j] = 10;
                            if(j > 2)
                            {    
                                if(BlockHeight[j - 1] != 10 && BlockHeight[j - 2] == 10)
                                    BlockHeight[j - 1] = 10;
                                if(BlockHeight[j - 1] != 10 && BlockHeight[j - 2] != 10 && BlockHeight[j - 3] == 10)
                                {
                                    BlockHeight[j - 1] = 10;
                                    BlockHeight[j - 2] = 10;
                                }
                            }  
                        }
                    }
                }
                flatZone --;
            }
            
            int lastBlockTime = 0;
            
            if(dir == "left")
            {
                var spriteChar = layer.CreateAnimation(p_char, charFCount, charFDelay, OsbLoopType.LoopForever, OsbOrigin.BottomLeft);
                int charX = (HSpriteVisible*charBlockPos) - 107 - HSpriteVisible;
                for(int i = charBlockPos; i > 0; i--)
                {
                    if(countS == 1)
                        spriteChar.Move(StartTime + (EndTime*HSpriteVisible)/Math.Abs(shift) * (charBlockPos - i), StartTime + (EndTime*HSpriteVisible)/Math.Abs(shift) * ((charBlockPos + 1) - i), charX, 480 - (BlockHeight[i] + 1)*(HSpriteVisible), charX, 480 - (BlockHeight[i-1] + 1)*(HSpriteVisible));
                    if(i == 1)
                        lastBlockTime = StartTime + (EndTime*HSpriteVisible)/Math.Abs(shift) * ((charBlockPos + 1) - i) + (EndTime*HSpriteVisible)/Math.Abs(shift);
                }
                if(countS == 1)
                    spriteChar.Scale(StartTime, StartTime, charSize, charSize);
                else spriteChar.Scale(lastBlockTime, lastBlockTime, charSize, charSize);

                for(int i = ((854/HSpriteVisible) + AddBlocks); i > (854/HSpriteVisible); i--)
                    spriteChar.Move(lastBlockTime + (EndTime*HSpriteVisible)/Math.Abs(shift) * (((854/HSpriteVisible) + AddBlocks) - i), lastBlockTime + (EndTime*HSpriteVisible)/Math.Abs(shift) * (((854/HSpriteVisible) + AddBlocks) + 1 - i), charX, 480 - (BlockHeight[i] + 1)*(HSpriteVisible), charX, 480 - (BlockHeight[i-1] + 1)*(HSpriteVisible));
            }
            else {
                var spriteChar = layer.CreateAnimation(p_char, charFCount, charFDelay, OsbLoopType.LoopForever, OsbOrigin.BottomRight);
                int charX = (HSpriteVisible*charBlockPos) - 107 + HSpriteVisible;
                for(int i = charBlockPos; i <= (854/HSpriteVisible); i++)
                {
                    if(countS == 1)
                        spriteChar.Move(StartTime + (EndTime*HSpriteVisible)/Math.Abs(shift) * (i - charBlockPos), StartTime + (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1 - charBlockPos), charX, 480 - (BlockHeight[i] + 1)*(HSpriteVisible), charX, 480 - (BlockHeight[i+1] + 1)*(HSpriteVisible));
                    if(i == (854/HSpriteVisible))
                        lastBlockTime = StartTime + (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1 - charBlockPos) - (EndTime*HSpriteVisible)/Math.Abs(shift);
                }
                if(countS == 1)
                {
                    spriteChar.FlipH(StartTime, StartTime);
                    spriteChar.Scale(StartTime, StartTime, charSize, charSize);
                }
                else 
                {
                    spriteChar.FlipH(lastBlockTime, lastBlockTime);
                    spriteChar.Scale(lastBlockTime, lastBlockTime, charSize, charSize);
                }

                for(int i = (854/HSpriteVisible); i < ((854/HSpriteVisible) + AddBlocks); i++)
                    spriteChar.Move(lastBlockTime + (EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854/HSpriteVisible)), lastBlockTime + (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1 - (854/HSpriteVisible)), charX, 480 - (BlockHeight[i] + 1)*(HSpriteVisible), charX, 480 - (BlockHeight[i+1] + 1)*(HSpriteVisible));
                spriteChar.Move(lastBlockTime + (EndTime*HSpriteVisible)/Math.Abs(shift) * (((854/HSpriteVisible) + AddBlocks) - (854/HSpriteVisible)),  lastBlockTime + (EndTime*HSpriteVisible)/Math.Abs(shift) * (((854/HSpriteVisible) + AddBlocks) - (854/HSpriteVisible)) + (EndTime*HSpriteVisible)/Math.Abs(shift), charX, 480 - (BlockHeight[((854/HSpriteVisible) + AddBlocks)] + 1)*(HSpriteVisible), charX, 480 - (BlockHeight[((854/HSpriteVisible) + AddBlocks)] + 1)*(HSpriteVisible));
            }
        }

//МЕТОДЫ ГЕНЕРАЦИИ
        public void plantsLayer(string currlayer, string pathP0, string pathP1, string pathP2, int[,] prevBlockArray, int floorID, string dir, bool flip, OsbOrigin Origin)
        {
            var layer = GetLayer(currlayer);
            var bitmap = GetMapsetBitmap(pathP0);
            int[] BlockHeight = new int[(854 / HSpriteVisible) + AddBlocks + 1];

            for(int j = 0; j <= (854 / HSpriteVisible) + AddBlocks; j++)
                for(int i = 1; i <= HeightGeneration - 1; i ++)
                {
                    if(prevBlockArray[i, j] == 1)
                        BlockHeight[j]++;
                }
            int plantMetr = 0;
            
            
            for(int i = 0; i <= (854 / HSpriteVisible) + AddBlocks; i++)
            {
                //ГЕНЕРАЦИЯ РАСТЕНИЙ
                plantMetr ++;
                string PlantPath = "";
                int PlantType = Random(0,3);
                switch(PlantType)
                {
                    case 0: PlantPath = pathP0; break;
                    case 1: PlantPath = pathP1; break;
                    case 2: PlantPath = pathP2; break;
                }

                int flipped = 0;
                if (flip)
                    flipped = Random(0,2);


                var bitmapPlant = GetMapsetBitmap(PlantPath);
                var spritePlant = layer.CreateSprite(PlantPath, Origin); 

                double plantShift = (double)bitmapPlant.Width*((EndTime*HSpriteVisible)/Math.Abs(shift))/14;
                int plantShiftToH = HSpriteVisible/2;

                int PlantGenerationRandom = Random(0, PlantGeneration);
                if(PlantGenerationRandom == 0 && plantMetr > DistBetweenPlants)
                    if(dir == "right")
                    {
                        plantMetr = 0;
                        if(!FromCorner)
                        {
                            if(i <= (854 / HSpriteVisible)) {
                                if ((EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) <= EndTime)
                                {
                                    spritePlant.Move(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (i * HSpriteVisible) - 107 + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), -107 - HSpriteVisible + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                    spritePlant.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime + plantShift, -107 - HSpriteVisible + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), -107 - HSpriteVisible - bitmapPlant.Width + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                    spritePlant.ScaleVec(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, 0.5, 0.5, 0.5, 0.5);
                                }
                                else
                                {
                                    
                                    spritePlant.Move(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (i * HSpriteVisible) - 107+ plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), -107 - HSpriteVisible + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                    spritePlant.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime + plantShift, -107 - HSpriteVisible + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), -107 - HSpriteVisible - bitmapPlant.Width + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                    spritePlant.ScaleVec(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, 0.5, 0.5, 0.5, 0.5);
                                }
                            } else {
                                if((EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime - plantShift >= StartTime)
                                {
                                    spritePlant.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime - plantShift, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime, 747 + bitmapPlant.Width + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), 747 + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                    spritePlant.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, 747 + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), -107 - HSpriteVisible + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                    spritePlant.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime + plantShift, -107 - HSpriteVisible + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), -107 - HSpriteVisible - bitmapPlant.Width + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                    spritePlant.ScaleVec((EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime,  0.5, 0.5, 0.5, 0.5);
                                }
                            }
                        } else if(i >= (854 / HSpriteVisible))
                        {
                            if((EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime - plantShift >= StartTime)
                            {
                                spritePlant.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime - plantShift, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime, 747 + bitmapPlant.Width + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), 747 + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                spritePlant.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, 747 + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), -107 - HSpriteVisible + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                spritePlant.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime + plantShift, -107 - HSpriteVisible + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), -107 - HSpriteVisible - bitmapPlant.Width + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                spritePlant.ScaleVec((EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, 0.5, 0.5, 0.5, 0.5);
                            }
                        }
                    }
                    else {
                        plantMetr = 0;
                        int reflectedI = (854 / HSpriteVisible) - i;
                        int razn = (EndTime*HSpriteVisible)/Math.Abs(shift) * (854 / HSpriteVisible) + ((AddBlocks + 1) * (EndTime*HSpriteVisible)/Math.Abs(shift));

                        if(!FromCorner)
                        {
                            if(i <= (854 / HSpriteVisible)) 
                            {
                                if ((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + StartTime <= EndTime)
                                {
                                    if(flipped == 1)
                                        spritePlant.FlipH(StartTime, StartTime);
                                    spritePlant.Move(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + (EndTime*HSpriteVisible)/Math.Abs(shift) + StartTime, ((i) * HSpriteVisible) - 107 - HSpriteVisible + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), 747 + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                    spritePlant.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + (EndTime*HSpriteVisible)/Math.Abs(shift) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + (EndTime*HSpriteVisible)/Math.Abs(shift) + StartTime + plantShift, 747 + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible),  747 + bitmapPlant.Width + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                    spritePlant.ScaleVec(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + (EndTime*HSpriteVisible)/Math.Abs(shift) + StartTime, 0.5, 0.5, 0.5, 0.5);
                                }
                                else
                                { 
                                    if(flipped == 1)
                                        spritePlant.FlipH(StartTime, StartTime);
                                    spritePlant.Move(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + (EndTime*HSpriteVisible)/Math.Abs(shift) + StartTime, ((i) * HSpriteVisible) - 107 - HSpriteVisible + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), 747 + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                    spritePlant.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + (EndTime*HSpriteVisible)/Math.Abs(shift) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + (EndTime*HSpriteVisible)/Math.Abs(shift) + StartTime + plantShift, 747 + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible),  747 + bitmapPlant.Width + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                    spritePlant.ScaleVec(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + (EndTime*HSpriteVisible)/Math.Abs(shift) + StartTime, 0.5, 0.5, 0.5, 0.5);
                                }
                            } else {
                                if((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn - plantShift >= StartTime)
                                {
                                    if(flipped == 1)
                                        spritePlant.FlipH((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn - plantShift, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn - plantShift);
                                    spritePlant.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn - plantShift, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn, -107 - HSpriteVisible - bitmapPlant.Width + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), -107 - HSpriteVisible + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                    spritePlant.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI + 1) + StartTime + razn , -107 - HSpriteVisible + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible) , 747 + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                    spritePlant.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI + 1) + StartTime + razn, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI + 1) + StartTime + razn + plantShift , 747 + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), 747 + bitmapPlant.Width + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                    spritePlant.ScaleVec((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI + 1) + StartTime + razn , 0.5, 0.5, 0.5, 0.5);
                                }
                            }   
                        } else if(i >= (854 / HSpriteVisible))
                        {
                            if((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn - plantShift >= StartTime)
                            {
                                if(flipped == 1)
                                    spritePlant.FlipH((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn - plantShift, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn - plantShift);
                                spritePlant.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn - plantShift, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn, -107 - HSpriteVisible - bitmapPlant.Width + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), -107 - HSpriteVisible + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                spritePlant.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI + 1) + StartTime + razn , -107 - HSpriteVisible + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), 747 + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                spritePlant.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI + 1) + StartTime + razn, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI + 1) + StartTime + razn + plantShift, 747 + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible), 747 + bitmapPlant.Width + plantShiftToH, 480 - (BlockHeight[i] * HSpriteVisible));
                                spritePlant.ScaleVec((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI + 1) + StartTime + razn ,  0.5, 0.5, 0.5, 0.5);
                            }
                        }
                    }
            }

        }

        List<int> Randomed = new List<int>();
        public void grassLayer(string currlayer, string pathG0, string pathG1, string pathG2, int[,] prevBlockArray, int floorID, string dir)
        {
            var layer = GetLayer(currlayer);
            var bitmap = GetMapsetBitmap(pathG0);
            int[] BlockHeight = new int[(854 / HSpriteVisible) + AddBlocks + 1];
            
            int flatZone = 10;
            for(int j = 0; j <= (854 / HSpriteVisible) + AddBlocks; j++)
                Randomed.Add(Random(0,500));

            for(int j = 0; j <= (854 / HSpriteVisible) + AddBlocks; j++)
            {
                if((Randomed[j] < 50) && (Randomed[j] > 20) && (flatZone <= 0))
                    flatZone = 10;
                if((Randomed[j] < 20) && (flatZone <= 0))
                    flatZone = 15;

                for(int i = 1; i <= HeightGeneration - 1; i ++)
                {
                    if(prevBlockArray[i, j] == 1)
                    {
                        if(flatZone <= 0)
                            BlockHeight[j] ++;
                        else{
                            if(flatZone > 10)
                                BlockHeight[j] = 15;
                            else
                                BlockHeight[j] = 10;
                            if(j > 2)
                            {    
                                if(BlockHeight[j - 1] != 10 && BlockHeight[j - 2] == 10)
                                    BlockHeight[j - 1] = 10;
                                if(BlockHeight[j - 1] != 10 && BlockHeight[j - 2] != 10 && BlockHeight[j - 3] == 10)
                                {
                                    BlockHeight[j - 1] = 10;
                                    BlockHeight[j - 2] = 10;
                                }
                            }  
                        }
                    }
                }
                flatZone --;
            }
            
            for(int i = 0; i <= (854 / HSpriteVisible) + AddBlocks; i++)
            {
                //ГЕНЕРАЦИЯ ВЕРХНЕГО СЛОЯ, ТРАВЫ

                string GrassPath = "";
                int GrassType = Random(0,3);
                switch(GrassType)
                {
                    case 0: GrassPath = pathG0; break;
                    case 1: GrassPath = pathG1; break;
                    case 2: GrassPath = pathG2; break;
                }


                var sprite = layer.CreateSprite(GrassPath, OsbOrigin.TopLeft);
                
                if(dir == "right")
                {
                    if(!FromCorner)
                    {
                        if(i <= (854 / HSpriteVisible)) {
                            if ((EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) <= EndTime)
                            {
                                sprite.Move(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (i * HSpriteVisible) - 107, 480 - (BlockHeight[i] * HSpriteVisible) - HSpriteVisible, -107 - HSpriteVisible, 480 - (BlockHeight[i] * HSpriteVisible) - HSpriteVisible);
                                sprite.ScaleVec(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height);
                            }
                            else
                            {
                                sprite.Move(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (i * HSpriteVisible) - 107, 480 - (BlockHeight[i] * HSpriteVisible) - HSpriteVisible, -107 - HSpriteVisible, 480 - (BlockHeight[i] * HSpriteVisible) - HSpriteVisible);
                                sprite.ScaleVec(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height);
                            }
                        } else {
                            sprite.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, 747, 480 - (BlockHeight[i] * HSpriteVisible) - HSpriteVisible, -107 - HSpriteVisible, 480 - (BlockHeight[i] * HSpriteVisible) - HSpriteVisible);
                            sprite.ScaleVec((EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height);
                        }
                    } else if(i >= (854 / HSpriteVisible))
                    {
                        sprite.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, 747, 480 - (BlockHeight[i] * HSpriteVisible) - HSpriteVisible, -107 - HSpriteVisible, 480 - (BlockHeight[i] * HSpriteVisible) - HSpriteVisible);
                        sprite.ScaleVec((EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height);
                    }
                }
                else {
                    int reflectedI = (854 / HSpriteVisible) - i;
                    int razn = (EndTime*HSpriteVisible)/Math.Abs(shift) * (854 / HSpriteVisible) + ((AddBlocks + 1) * (EndTime*HSpriteVisible)/Math.Abs(shift));

                    if(!FromCorner)
                    {
                        if(i <= (854 / HSpriteVisible)) 
                        {
                            if ((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + StartTime <= EndTime)
                            {
                                sprite.Move(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + (EndTime*HSpriteVisible)/Math.Abs(shift) + StartTime, ((i) * HSpriteVisible) - 107 - HSpriteVisible, 480 - (BlockHeight[i] * HSpriteVisible) - HSpriteVisible, 747, 480 - (BlockHeight[i] * HSpriteVisible) - HSpriteVisible);
                                sprite.ScaleVec(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + (EndTime*HSpriteVisible)/Math.Abs(shift) + StartTime, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height);
                            }
                            else
                            { 
                                sprite.Move(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + (EndTime*HSpriteVisible)/Math.Abs(shift) + StartTime, ((i) * HSpriteVisible) - 107 - HSpriteVisible, 480 - (BlockHeight[i] * HSpriteVisible) - HSpriteVisible, 747, 480 - (BlockHeight[i] * HSpriteVisible) - HSpriteVisible);
                                sprite.ScaleVec(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + (EndTime*HSpriteVisible)/Math.Abs(shift) + StartTime, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height);
                            }
                        } else {
                            sprite.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI + 1) + StartTime + razn , -107 - HSpriteVisible, 480 - (BlockHeight[i] * HSpriteVisible) - HSpriteVisible, 747, 480 - (BlockHeight[i] * HSpriteVisible) - HSpriteVisible);
                            sprite.ScaleVec((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI + 1) + StartTime + razn , (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height);
                        }
                    } else if(i >= (854 / HSpriteVisible))
                    {
                        sprite.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI + 1) + StartTime + razn , -107 - HSpriteVisible, 480 - (BlockHeight[i] * HSpriteVisible) - HSpriteVisible, 747, 480 - (BlockHeight[i] * HSpriteVisible) - HSpriteVisible);
                        sprite.ScaleVec((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI + 1) + StartTime + razn , (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height);
                    }
                }
            }
        }

        public int[,] layer(string currlayer, string pathD0, string pathD1, string pathD2, int y, int[,] prevBlockArray, int floorID, string dir)
        {
            //ГЕНЕРАЦИЯ ЗЕМЛИ
            
            var layer = GetLayer(currlayer);
            var bitmap = GetMapsetBitmap(pathD0);

            int[] number = new int[(854 / HSpriteVisible) + AddBlocks + 1];
            bool[] block = new bool[(854 / HSpriteVisible) + AddBlocks + 1];
            bool[] lastBlock = new bool[(854 / HSpriteVisible) + AddBlocks + 1];

            for(int i = 0; i <= (854 / HSpriteVisible) + AddBlocks; i++)
            {
                number[i] = Random(0,ToRandom);
                if(number[i] > floorID*20)
                    block[i] = true;
                else block[i] = false;

                if(firstFloor && i > 0 && i < (854 / HSpriteVisible) + AddBlocks) 
                    if(number[i] > floorID*TotalHeight && (prevBlockArray[floorID - 1, i - 1] == 1 && prevBlockArray[floorID - 1, i + 1] == 1))
                        lastBlock[i] = true;
                    else lastBlock[i] = false;
            }

            int SmoothType = 0;
            switch(Smoothed)
            {
                case Smooth.Off: SmoothType = 0; break;
                case Smooth.SmoothX2: SmoothType = 1; break;
                case Smooth.SmoothX3: SmoothType = 2; break;
                case Smooth.SmoothPropX2: SmoothType = 3; break;
                case Smooth.SmoothPropX3: SmoothType = 3; break;
            }

            for(int i = 0; i <= (854 / HSpriteVisible) + AddBlocks; i++)
            {
                string DirtPath = "";
                int GrassType = Random(0,3);
                switch(GrassType)
                {
                    case 0: DirtPath = pathD0; break;
                    case 1: DirtPath = pathD1; break;
                    case 2: DirtPath = pathD2; break;
                }

                if((i == 61 && floorID < SectorChangeHeight)||(i != 61))
                if((!firstFloor) || (firstFloor && prevBlockArray[floorID-1,i] == 1))
                {
                    if((!firstFloor) || (firstFloor && i > 1 && i < (854 / HSpriteVisible) + AddBlocks - 1))
                        if((!firstFloor) || (prevBlockArray[floorID - 1, i - 1] == 1 && prevBlockArray[floorID - 1, i + 1] == 1))
                        if((!firstFloor) || 
                        ((SmoothType == 4 && block[i] && block[i - 1] && block[i + 2] && block[i - 2] && block[i + 2]) || 
                        (SmoothType == 3 && block[i] && block[i - 1] && block[i + 1]) || 
                        (SmoothType == 2 && block[i] && lastBlock[i - 1] && lastBlock[i + 1]) && lastBlock[i - 2] && lastBlock[i + 2]) || 
                        (SmoothType == 1 && block[i] && lastBlock[i - 1] && lastBlock[i + 1]) || 
                        (SmoothType == 0 && block[i]))
                        {
                            prevBlockArray[floorID,i] = 1;  

                            var sprite = layer.CreateSprite(DirtPath, OsbOrigin.TopLeft);

                            if(dir == "right")
                            {
                                if(!FromCorner)
                                {
                                    if(i <= (854 / HSpriteVisible)) 
                                    {
                                        if ((EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime <= EndTime)
                                        {
                                            sprite.Move(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (i * HSpriteVisible) - 107, y, -107 - HSpriteVisible, y);
                                            sprite.ScaleVec(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height);
                                        }
                                        else
                                        { 
                                            sprite.Move(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (i * HSpriteVisible) - 107, y, -107 - HSpriteVisible, y);
                                            sprite.ScaleVec(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height);
                                        }
                                    } else {
                                        sprite.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, 747, y, -107 - HSpriteVisible, y);
                                        sprite.ScaleVec((EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height);
                                    }
                                } else if(i >= (854 / HSpriteVisible))
                                {
                                    sprite.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, 747, y, -107 - HSpriteVisible, y);
                                    sprite.ScaleVec((EndTime*HSpriteVisible)/Math.Abs(shift) * (i - (854 / HSpriteVisible)) + StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (i + 1) + StartTime, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height);
                                    
                                }
                            }
                            else
                            {
                                int reflectedI = (854 / HSpriteVisible) - i;
                                int razn = (EndTime*HSpriteVisible)/Math.Abs(shift) * (854 / HSpriteVisible) + ((AddBlocks + 1) * (EndTime*HSpriteVisible)/Math.Abs(shift));

                                if(!FromCorner)
                                {
                                    if(i <= (854 / HSpriteVisible)) 
                                    {
                                        if ((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + StartTime <= EndTime)
                                        {
                                            sprite.Move(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + (EndTime*HSpriteVisible)/Math.Abs(shift) + StartTime, ((i) * HSpriteVisible) - 107 - HSpriteVisible, y, 747, y);
                                            sprite.ScaleVec(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + (EndTime*HSpriteVisible)/Math.Abs(shift) + StartTime, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height);
                                        }
                                        else
                                        { 
                                            sprite.Move(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + (EndTime*HSpriteVisible)/Math.Abs(shift) + StartTime, ((i) * HSpriteVisible) - 107 - HSpriteVisible, y, 747, y);
                                            sprite.ScaleVec(StartTime, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI) + (EndTime*HSpriteVisible)/Math.Abs(shift) + StartTime, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height);
                                        }
                                    } else {
                                        sprite.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI + 1) + StartTime + razn , -107 - HSpriteVisible, y, 747, y);
                                        sprite.ScaleVec((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI + 1) + StartTime + razn , (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height);
                                    }
                                } else if(i >= (854 / HSpriteVisible))
                                {
                                    sprite.Move((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI + 1) + StartTime + razn , -107 - HSpriteVisible, y, 747, y);
                                    sprite.ScaleVec((EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI - (854 / HSpriteVisible)) + StartTime + razn, (EndTime*HSpriteVisible)/Math.Abs(shift) * (reflectedI + 1) + StartTime + razn , (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height, (float)HSpriteVisible / bitmap.Width, (float)HSpriteVisible / bitmap.Height);
                                }
                            }
                        }
                } 
                else
                {
                    prevBlockArray[floorID,i] = 0; 
                }    
            }
            
            return prevBlockArray;
        }
    }
}
