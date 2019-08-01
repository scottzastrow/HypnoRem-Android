/*
 * Copyright (c) All Rights Reserved, VERGOSOFT LLC
 * Title: HypnoRem
 * Author: Scott Zastrow
 * 
 */
 using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class SoundScape : MonoBehaviour {

    public AudioMixer nightMixer;
    public AudioMixerSnapshot nightOff;
    public AudioMixerSnapshot NToneA;
    public AudioMixerSnapshot NTtwoA;
    public AudioMixerSnapshot NTthreeA;
    public AudioMixerSnapshot NTfourA;

    public AudioMixerSnapshot NToneB;
    public AudioMixerSnapshot NTtwoB;
    public AudioMixerSnapshot NTthreeB;
    public AudioMixerSnapshot NTfourB;

    public AudioMixerSnapshot NToneC;
    public AudioMixerSnapshot NTtwoC;
    public AudioMixerSnapshot NTthreeC;
    public AudioMixerSnapshot NTfourC;
    public AudioMixerSnapshot NTfiveC;
    //Water
    public AudioMixer waterMixer;
    public AudioMixerSnapshot waterOff;
    public AudioMixerSnapshot WToneA;
    public AudioMixerSnapshot WTtwoA;
    public AudioMixerSnapshot WTthreeA;
    public AudioMixerSnapshot WTfourA;

    public AudioMixerSnapshot WToneB;
    public AudioMixerSnapshot WTtwoB;
    public AudioMixerSnapshot WTthreeB;
    public AudioMixerSnapshot WTfourB;

    public AudioMixerSnapshot WToneC;
    public AudioMixerSnapshot WTtwoC;
    public AudioMixerSnapshot WTthreeC;
    public AudioMixerSnapshot WTfourC;
    public AudioMixerSnapshot WTfiveC;
    //Rain
    public AudioMixer rainMixer;
    public AudioMixerSnapshot rainOff;
    public AudioMixerSnapshot RNoneA;
    public AudioMixerSnapshot RNtwoA;
    public AudioMixerSnapshot RNthreeA;
    public AudioMixerSnapshot RNfourA;

    public AudioMixerSnapshot RNoneB;
    public AudioMixerSnapshot RNtwoB;
    public AudioMixerSnapshot RNthreeB;
    public AudioMixerSnapshot RNfourB;

    public AudioMixerSnapshot RNoneC;
    public AudioMixerSnapshot RNtwoC;
    public AudioMixerSnapshot RNthreeC;
    public AudioMixerSnapshot RNfourC;
    public AudioMixerSnapshot RNfiveC;
    //Wave
    public AudioMixer waveMixer;
    public AudioMixerSnapshot waveOff;
    public AudioMixerSnapshot WVoneA;
    public AudioMixerSnapshot WVtwoA;
    public AudioMixerSnapshot WVthreeA;
    public AudioMixerSnapshot WVfourA;

    public AudioMixerSnapshot WVoneB;
    public AudioMixerSnapshot WVtwoB;
    public AudioMixerSnapshot WVthreeB;
    public AudioMixerSnapshot WVfourB;

    public AudioMixerSnapshot WVoneC;
    public AudioMixerSnapshot WVtwoC;
    public AudioMixerSnapshot WVthreeC;
    public AudioMixerSnapshot WVfourC;
    public AudioMixerSnapshot WVfiveC;
    //Wind
    public AudioMixer windMixer;
    public AudioMixerSnapshot windOff;
    public AudioMixerSnapshot WDoneA;
    public AudioMixerSnapshot WDoneC;
    public AudioMixerSnapshot WDoneB;

    public AudioMixerSnapshot WDtwoA;
    public AudioMixerSnapshot WDtwoC;
    public AudioMixerSnapshot WDtwoB;

    public AudioMixerSnapshot WDthreeA;
    public AudioMixerSnapshot WDthreeC;
    public AudioMixerSnapshot WDthreeB;

    public AudioMixerSnapshot WDfourA;
    public AudioMixerSnapshot WDfourC;
    public AudioMixerSnapshot WDfourB;
    public AudioMixerSnapshot WDfiveC;


    //Water AudioSource
    public AudioSource theBase;
    public AudioSource theDeep;
    public AudioSource theShallow;
    public AudioSource thePop;
    //Rain AudioSource
    public AudioSource tinRoof;
    public AudioSource highRain;
    public AudioSource coveredRain;
    public AudioSource mediumRain;
    public AudioSource windowRain;
    public AudioSource fullRain;
    public AudioSource hardRain;
    public AudioSource thunderOne;
    public AudioSource thunderTwo;
    public AudioSource thunderThree;
    public AudioSource tentOne;
    //Night AudioSource
    public AudioSource FrogNight;
    public AudioSource SkinnyNight;
    public AudioSource LocusNight;
    public AudioSource RattleNight;
    public AudioSource RainNight;
    public AudioSource FlyNight;
    public AudioSource AcitveNight;
    public AudioSource IntenseNight;
    public AudioSource NightBase;
    public AudioSource WoopWoop;
    public AudioSource LightCricket;
    //Wave AudioSource
    public AudioSource airSpry;
    public AudioSource airyWaves;
    public AudioSource birdsWaves;
    public AudioSource crashWaves;
    public AudioSource longSand;
    public AudioSource mediumFast;
    public AudioSource roarWave;
    public AudioSource seaGulls;
    //Wind AudioSource
    public AudioSource backYard;
    public AudioSource windChimes;
    public AudioSource windChirp;
    public AudioSource windFour;
    public AudioSource windOne;
    public AudioSource windOwl;
    public AudioSource windScuffle;
    public AudioSource windSix;
    public AudioSource windBirds;
    public AudioSource windTwo;

    public GameObject settingsPanel;

    public Image logo;

    public Slider volumeSlider;
    public Slider durationSlider;
    public Slider soundTypeSlider;

    public Sprite pauseSprite;
    public Sprite stopSprite;
    public Button playButton;

    public Text soundTypeText;

    public Toggle fadeToggle;
    public Toggle cycleToggle;

    private float holdTime;
    private float transTime;
    private bool switchOnOff;
    private bool fadeAudio;
    private bool breakOut;
    private bool iJustHitPlay;
    private string mixerVolume;
    private float masterVolume;

    private Color color1 = new Color(1f, 1f, 1f, 1f);
    private Color color2 = new Color(1f, 1f, 1f, 0f);

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        breakOut = false;
        iJustHitPlay = false;
        Application.runInBackground = true;
        logo.CrossFadeAlpha(1, 1f, false);
        if (PlayerPrefs.HasKey("volume"))
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
        if (PlayerPrefs.HasKey("duration"))
            durationSlider.value = PlayerPrefs.GetFloat("duration");
        if (PlayerPrefs.HasKey("sound"))
            soundTypeSlider.value = PlayerPrefs.GetFloat("sound");
        if (PlayerPrefs.HasKey("fade")) //Fade Audio Volume
        {
            if (PlayerPrefs.GetInt("fade") == 1)
                fadeToggle.isOn = true;
            else
                fadeToggle.isOn = false;
        }
        if (PlayerPrefs.HasKey("cycle"))
        {
            if (PlayerPrefs.GetInt("cycle") == 1)
                cycleToggle.isOn = true;
            else
                cycleToggle.isOn = false;
        }
        if (soundTypeSlider.value == 1)
        {
            soundTypeText.text = "Forest Night";
        }
        else if (soundTypeSlider.value == 2)
        {
            soundTypeText.text = "Ocean Depths";
        }
        else if (soundTypeSlider.value == 3)
        {
            soundTypeText.text = "Thunderstorm";
        }
        else if (soundTypeSlider.value == 4)
        {
            soundTypeText.text = "Tropic Wave";
        }
        else if (soundTypeSlider.value == 5)
        {
            soundTypeText.text = "Wind Blown";
        }

        holdTime = durationSlider.value;
        transTime = .33f * holdTime;
        switchOnOff = false; //also add to pause

        volumeSlider.onValueChanged.AddListener(volumeListener);
        durationSlider.onValueChanged.AddListener(durationListener);
        soundTypeSlider.onValueChanged.AddListener(soundListener);
        fadeToggle.onValueChanged.AddListener((value) => {
            fadeListener(value); 
        }
       );
        cycleToggle.onValueChanged.AddListener((value) => {
            cycleListener(value);
        }
      );
    }
    void Update()
    {
        if(switchOnOff == false)
            logo.CrossFadeAlpha(1, 1f, false);

        //Debug.Log("BreakOut: " + breakOut);
        //Debug.Log("SwitchOnOff" + switchOnOff);

        if (switchOnOff == false && breakOut == true)
        {
            StartCoroutine(safeButton());
        }

    }
    IEnumerator safeButton()
    {
        playButton.interactable = false;
        yield return new WaitForSeconds(4f);
        playButton.interactable = true;

    }
    public void fadeListener(bool value)
    {
        //print("fade Value: " + value);
        PlayerPrefs.SetInt("fade", value ? 1 : 0);
        //print("fade: "+PlayerPrefs.GetInt("fade"));
        if (switchOnOff == true)
            stopIt();
    }
    public void cycleListener(bool value)
    {
        PlayerPrefs.SetInt("cycle", value ? 1 : 0);
        if (switchOnOff == true)
            stopIt();
    }
    public void durationListener(float value)
    {
        PlayerPrefs.SetFloat("duration", value);
        holdTime = value;
        transTime = .33f * holdTime;
        if (switchOnOff == true)
            stopIt();

    }
    public void volumeListener(float value)
    {
        PlayerPrefs.SetFloat("volume", value);
        if (switchOnOff == true)
            stopIt();
    }
    public void soundListener(float value)
    {
        PlayerPrefs.SetFloat("sound", value);
        if (value == 1)
        {
            soundTypeText.text = "Forest Night";
            mixerVolume = "nightVolume";
        }
        else if (value == 2)
        {
            soundTypeText.text = "Ocean Depths";
            mixerVolume = "waterVolume";
        }
        else if (value == 3)
        {
            soundTypeText.text = "Thunderstorm";
            mixerVolume = "rainVolume";
        }
        else if (value == 4)
        {
            soundTypeText.text = "Tropic Wave";
            mixerVolume = "waveVolume";
        }
        else if (value == 5)
        {
            soundTypeText.text = "Wind Blown";
            mixerVolume = "windVolume";
        }

        if (switchOnOff == true)
            stopIt();
    }
    public void pauseHypnoRem()
    {
        if (Time.timeScale == 1.0f)
        {
            playButton.image.overrideSprite = pauseSprite;
            Time.timeScale = 0.0f;
        }
        else if (Time.timeScale == 0.0f)
        {
            playButton.image.overrideSprite = null;
            Time.timeScale = 1.0f;
        }
    }
    IEnumerator changeColor()
    {
        yield return new WaitForSeconds(15f);
        logo.CrossFadeAlpha(0, 1f, false);

    }
    public void stopIt()
    {
        if (switchOnOff == false)
        {
            if (soundTypeSlider.value == 1)
            {
                startNight();
                mixerVolume = "nightVolume";
                masterVolume = volumeSlider.value;
                holdTime = durationSlider.value;
                transTime = .33f * holdTime;
                iJustHitPlay = true;
                runLoop(nightMixer, nightOff, NToneA, NTtwoA, NTthreeA, NTfourA, NToneB, NTtwoB, NTthreeB, NTfourB, NToneC, NTtwoC, NTthreeC, NTfourC, NTfiveC);
           }
            else if (soundTypeSlider.value == 2)
            {
                startWater();
                mixerVolume = "waterVolume";
                masterVolume = volumeSlider.value;
                holdTime = durationSlider.value;
                transTime = .33f * holdTime;
                iJustHitPlay = true;
                runLoop(waterMixer, waterOff, WToneA, WTtwoA, WTthreeA, WTfourA, WToneB, WTtwoB, WTthreeB, WTfourB, WToneC, WTtwoC, WTthreeC, WTfourC, WTfiveC);
            }
            else if (soundTypeSlider.value == 3)
            {
                startRain();
                mixerVolume = "rainVolume";
                masterVolume = volumeSlider.value;
                holdTime = durationSlider.value;
                transTime = .33f * holdTime;
                iJustHitPlay = true;
                runLoop(rainMixer, rainOff, RNoneA, RNtwoA, RNthreeA, RNfourA, RNoneB, RNtwoB, RNthreeB, RNfourB, RNoneC, RNtwoC, RNthreeC, RNfourC, RNfiveC);
             }
            else if (soundTypeSlider.value == 4)
            {
                startWave();
                mixerVolume = "waveVolume";
                masterVolume = volumeSlider.value;
                holdTime = durationSlider.value;
                transTime = .33f * holdTime;
                iJustHitPlay = true;
                runLoop(waveMixer, waveOff, WVoneA, WVtwoA, WVthreeA, WVfourA, WVoneB, WVtwoB, WVthreeB, WVfourB, WVoneC, WVtwoC, WVthreeC, WVfourC, WVfiveC);
            }
            else if (soundTypeSlider.value == 5)
            {
                startWind();
                mixerVolume = "windVolume";
                masterVolume = volumeSlider.value;
                holdTime = durationSlider.value;
                transTime = .33f * holdTime;
                iJustHitPlay = true;
                runLoop(windMixer, windOff ,WDoneA, WDtwoA, WDthreeA, WDfourA, WDoneB, WDtwoB, WDthreeB, WDfourB, WDoneC, WDtwoC, WDthreeC, WDfourC, WDfiveC);
            }
            switchOnOff = true;
            playButton.image.overrideSprite = stopSprite;
            StartCoroutine(changeColor());
            settingsPanel.SetActive(false);
            PanelManager.changeSettings = false;

        }
        else if (switchOnOff == true)
        {
            StartCoroutine(stoppingAllAudio());

            switchOnOff = false;
            breakOut = true;
            playButton.image.overrideSprite = null;
            logo.CrossFadeAlpha(1, 1f, false);
        }
    }
    IEnumerator stoppingAllAudio()
    {

        if (FrogNight.isPlaying)
            nightOff.TransitionTo(3f);
        if (theBase.isPlaying)
            waterOff.TransitionTo(3f);
        if (tinRoof.isPlaying)
            rainOff.TransitionTo(3f);
        if (airSpry.isPlaying)
            waveOff.TransitionTo(3f);
        if (backYard.isPlaying)
            windOff.TransitionTo(3f);
        yield return new WaitForSeconds(3f);

        stopAll();
        switchOnOff = false;
        breakOut = false;
    }
    private void stopAll()
    {
        //Stop Water AudioSource
        if (theBase.isPlaying)
            theBase.Stop();
        if (theDeep.isPlaying)
            theDeep.Stop();
        if (theShallow.isPlaying)
            theShallow.Stop();
        if (thePop.isPlaying)
            thePop.Stop();
        //Stop Rain AudioSource
        if (tinRoof.isPlaying)
            tinRoof.Stop();
        if (highRain.isPlaying)
            highRain.Stop();
        if (coveredRain.isPlaying)
            coveredRain.Stop();
        if (mediumRain.isPlaying)
            mediumRain.Stop();
        if (windowRain.isPlaying)
            windowRain.Stop();
        if (fullRain.isPlaying)
            fullRain.Stop();
        if (hardRain.isPlaying)
            hardRain.Stop();
        if (thunderOne.isPlaying)
            thunderOne.Stop();
        if (thunderTwo.isPlaying)
            thunderTwo.Stop();
        if (thunderThree.isPlaying)
            thunderThree.Stop();
        if (tentOne.isPlaying)
            tentOne.Stop();
        //Stop Night AudioSource
        if (FrogNight.isPlaying)
            FrogNight.Stop();
        if (SkinnyNight.isPlaying)
            SkinnyNight.Stop();
        if (LocusNight.isPlaying)
            LocusNight.Stop();
        if (RattleNight.isPlaying)
            RattleNight.Stop();
        if (RainNight.isPlaying)
            RainNight.Stop();
        if (FlyNight.isPlaying)
            FlyNight.Stop();
        if (AcitveNight.isPlaying)
            AcitveNight.Stop();
        if (IntenseNight.isPlaying)
            IntenseNight.Stop();
        if (NightBase.isPlaying)
            NightBase.Stop();
        if (WoopWoop.isPlaying)
            WoopWoop.Stop();
        if (LightCricket.isPlaying)
            LightCricket.Stop();
        //Stop Wave AudioSource
        if (airSpry.isPlaying)
            airSpry.Stop();
        if (airyWaves.isPlaying)
            airyWaves.Stop();
        if (birdsWaves.isPlaying)
            birdsWaves.Stop();
        if (crashWaves.isPlaying)
            crashWaves.Stop();
        if (longSand.isPlaying)
            longSand.Stop();
        if (mediumFast.isPlaying)
            mediumFast.Stop();
        if (roarWave.isPlaying)
            roarWave.Stop();
        if (seaGulls.isPlaying)
            seaGulls.Stop();
        //Stop Wind AudioSource
        if (backYard.isPlaying)
            backYard.Stop();
        if (windChimes.isPlaying)
            windChimes.Stop();
        if (windChirp.isPlaying)
            windChirp.Stop();
        if (windFour.isPlaying)
            windFour.Stop();
        if (windOne.isPlaying)
            windOne.Stop();
        if (windOwl.isPlaying)
            windOwl.Stop();
        if (windScuffle.isPlaying)
            windScuffle.Stop();
        if (windSix.isPlaying)
            windSix.Stop();
        if (windBirds.isPlaying)
            windBirds.Stop();
        if (windTwo.isPlaying)
            windTwo.Stop();
    }
    private void startNight()
    {
        //Stop Water AudioSource
        if (theBase.isPlaying)
            theBase.Stop();
        if (theDeep.isPlaying)
            theDeep.Stop();
        if (theShallow.isPlaying)
            theShallow.Stop();
        if (thePop.isPlaying)
            thePop.Stop();
        //Stop Rain AudioSource
        if (tinRoof.isPlaying)
            tinRoof.Stop();
        if (highRain.isPlaying)
            highRain.Stop();
        if (coveredRain.isPlaying)
            coveredRain.Stop();
        if (mediumRain.isPlaying)
            mediumRain.Stop();
        if (windowRain.isPlaying)
            windowRain.Stop();
        if (fullRain.isPlaying)
            fullRain.Stop();
        if (hardRain.isPlaying)
            hardRain.Stop();
        if (thunderOne.isPlaying)
            thunderOne.Stop();
        if (thunderTwo.isPlaying)
            thunderTwo.Stop();
        if (thunderThree.isPlaying)
            thunderThree.Stop();
        if (tentOne.isPlaying)
            tentOne.Stop();
        //Start Night AudioSource
        if (!FrogNight.isPlaying)
            FrogNight.Play();
        if (!SkinnyNight.isPlaying)
            SkinnyNight.Play();
        if (!LocusNight.isPlaying)
            LocusNight.Play();
        if (!RattleNight.isPlaying)
            RattleNight.Play();
        if (!RainNight.isPlaying)
            RainNight.Play();
        if (!FlyNight.isPlaying)
            FlyNight.Play();
        if (!AcitveNight.isPlaying)
            AcitveNight.Play();
        if (!IntenseNight.isPlaying)
            IntenseNight.Play();
        if (!NightBase.isPlaying)
            NightBase.Play();
        if (!WoopWoop.isPlaying)
            WoopWoop.Play();
        if (!LightCricket.isPlaying)
            LightCricket.Play();
        //Stop Wave AudioSource
        if (airSpry.isPlaying)
            airSpry.Stop();
        if (airyWaves.isPlaying)
            airyWaves.Stop();
        if (birdsWaves.isPlaying)
            birdsWaves.Stop();
        if (crashWaves.isPlaying)
            crashWaves.Stop();
        if (longSand.isPlaying)
            longSand.Stop();
        if (mediumFast.isPlaying)
            mediumFast.Stop();
        if (roarWave.isPlaying)
            roarWave.Stop();
        if (seaGulls.isPlaying)
            seaGulls.Stop();
        //Stop Wind AudioSource
        if (backYard.isPlaying)
            backYard.Stop();
        if (windChimes.isPlaying)
            windChimes.Stop();
        if (windChirp.isPlaying)
            windChirp.Stop();
        if (windFour.isPlaying)
            windFour.Stop();
        if (windOne.isPlaying)
            windOne.Stop();
        if (windOwl.isPlaying)
            windOwl.Stop();
        if (windScuffle.isPlaying)
            windScuffle.Stop();
        if (windSix.isPlaying)
            windSix.Stop();
        if (windBirds.isPlaying)
            windBirds.Stop();
        if (windTwo.isPlaying)
            windTwo.Stop();
    }
    private void startWater()
    {
        //Start Water AudioSource
        if (!theBase.isPlaying)
            theBase.Play();
        if (!theDeep.isPlaying)
            theDeep.Play();
        if (!theShallow.isPlaying)
            theShallow.Play();
        if (!thePop.isPlaying)
            thePop.Play();
        //Stop Rain AudioSource
        if (tinRoof.isPlaying)
            tinRoof.Stop();
        if (highRain.isPlaying)
            highRain.Stop();
        if (coveredRain.isPlaying)
            coveredRain.Stop();
        if (mediumRain.isPlaying)
            mediumRain.Stop();
        if (windowRain.isPlaying)
            windowRain.Stop();
        if (fullRain.isPlaying)
            fullRain.Stop();
        if (hardRain.isPlaying)
            hardRain.Stop();
        if (thunderOne.isPlaying)
            thunderOne.Stop();
        if (thunderTwo.isPlaying)
            thunderTwo.Stop();
        if (thunderThree.isPlaying)
            thunderThree.Stop();
        if (tentOne.isPlaying)
            tentOne.Stop();
        //Stop Night AudioSource
        if (FrogNight.isPlaying)
            FrogNight.Stop();
        if (SkinnyNight.isPlaying)
            SkinnyNight.Stop();
        if (LocusNight.isPlaying)
            LocusNight.Stop();
        if (RattleNight.isPlaying)
            RattleNight.Stop();
        if (RainNight.isPlaying)
            RainNight.Stop();
        if (FlyNight.isPlaying)
            FlyNight.Stop();
        if (AcitveNight.isPlaying)
            AcitveNight.Stop();
        if (IntenseNight.isPlaying)
            IntenseNight.Stop();
        if (NightBase.isPlaying)
            NightBase.Stop();
        if (WoopWoop.isPlaying)
            WoopWoop.Stop();
        if (LightCricket.isPlaying)
            LightCricket.Stop();
        //Stop Wave AudioSource
        if (airSpry.isPlaying)
            airSpry.Stop();
        if (airyWaves.isPlaying)
            airyWaves.Stop();
        if (birdsWaves.isPlaying)
            birdsWaves.Stop();
        if (crashWaves.isPlaying)
            crashWaves.Stop();
        if (longSand.isPlaying)
            longSand.Stop();
        if (mediumFast.isPlaying)
            mediumFast.Stop();
        if (roarWave.isPlaying)
            roarWave.Stop();
        if (seaGulls.isPlaying)
            seaGulls.Stop();
        //Stop Wind AudioSource
        if (backYard.isPlaying)
            backYard.Stop();
        if (windChimes.isPlaying)
            windChimes.Stop();
        if (windChirp.isPlaying)
            windChirp.Stop();
        if (windFour.isPlaying)
            windFour.Stop();
        if (windOne.isPlaying)
            windOne.Stop();
        if (windOwl.isPlaying)
            windOwl.Stop();
        if (windScuffle.isPlaying)
            windScuffle.Stop();
        if (windSix.isPlaying)
            windSix.Stop();
        if (windBirds.isPlaying)
            windBirds.Stop();
        if (windTwo.isPlaying)
            windTwo.Stop();
    }
    private void startRain()
    {
        //Stop Water AudioSource
        if (theBase.isPlaying)
            theBase.Stop();
        if (theDeep.isPlaying)
            theDeep.Stop();
        if (theShallow.isPlaying)
            theShallow.Stop();
        if (thePop.isPlaying)
            thePop.Stop();
        //Start Rain AudioSource
        if (!tinRoof.isPlaying)
            tinRoof.Play();
        if (!highRain.isPlaying)
            highRain.Play();
        if (!coveredRain.isPlaying)
            coveredRain.Play();
        if (!mediumRain.isPlaying)
            mediumRain.Play();
        if (!windowRain.isPlaying)
            windowRain.Play();
        if (!fullRain.isPlaying)
            fullRain.Play();
        if (!hardRain.isPlaying)
            hardRain.Play();
        if (!thunderOne.isPlaying)
            thunderOne.Play();
        if (!thunderTwo.isPlaying)
            thunderTwo.Play();
        if (!thunderThree.isPlaying)
            thunderThree.Play();
        if (!tentOne.isPlaying)
            tentOne.Play();
        //Stop Night AudioSource
        if (FrogNight.isPlaying)
            FrogNight.Stop();
        if (SkinnyNight.isPlaying)
            SkinnyNight.Stop();
        if (LocusNight.isPlaying)
            LocusNight.Stop();
        if (RattleNight.isPlaying)
            RattleNight.Stop();
        if (RainNight.isPlaying)
            RainNight.Stop();
        if (FlyNight.isPlaying)
            FlyNight.Stop();
        if (AcitveNight.isPlaying)
            AcitveNight.Stop();
        if (IntenseNight.isPlaying)
            IntenseNight.Stop();
        if (NightBase.isPlaying)
            NightBase.Stop();
        if (WoopWoop.isPlaying)
            WoopWoop.Stop();
        if (LightCricket.isPlaying)
            LightCricket.Stop();
        //Stop Wave AudioSource
        if (airSpry.isPlaying)
            airSpry.Stop();
        if (airyWaves.isPlaying)
            airyWaves.Stop();
        if (birdsWaves.isPlaying)
            birdsWaves.Stop();
        if (crashWaves.isPlaying)
            crashWaves.Stop();
        if (longSand.isPlaying)
            longSand.Stop();
        if (mediumFast.isPlaying)
            mediumFast.Stop();
        if (roarWave.isPlaying)
            roarWave.Stop();
        if (seaGulls.isPlaying)
            seaGulls.Stop();
        //Stop Wind AudioSource
        if (backYard.isPlaying)
            backYard.Stop();
        if (windChimes.isPlaying)
            windChimes.Stop();
        if (windChirp.isPlaying)
            windChirp.Stop();
        if (windFour.isPlaying)
            windFour.Stop();
        if (windOne.isPlaying)
            windOne.Stop();
        if (windOwl.isPlaying)
            windOwl.Stop();
        if (windScuffle.isPlaying)
            windScuffle.Stop();
        if (windSix.isPlaying)
            windSix.Stop();
        if (windBirds.isPlaying)
            windBirds.Stop();
        if (windTwo.isPlaying)
            windTwo.Stop();
    }
    private void startWave()
    {
        //Stop Water AudioSource
        if (theBase.isPlaying)
            theBase.Stop();
        if (theDeep.isPlaying)
            theDeep.Stop();
        if (theShallow.isPlaying)
            theShallow.Stop();
        if (thePop.isPlaying)
            thePop.Stop();
        //Stop Rain AudioSource
        if (tinRoof.isPlaying)
            tinRoof.Stop();
        if (highRain.isPlaying)
            highRain.Stop();
        if (coveredRain.isPlaying)
            coveredRain.Stop();
        if (mediumRain.isPlaying)
            mediumRain.Stop();
        if (windowRain.isPlaying)
            windowRain.Stop();
        if (fullRain.isPlaying)
            fullRain.Stop();
        if (hardRain.isPlaying)
            hardRain.Stop();
        if (thunderOne.isPlaying)
            thunderOne.Stop();
        if (thunderTwo.isPlaying)
            thunderTwo.Stop();
        if (thunderThree.isPlaying)
            thunderThree.Stop();
        if (tentOne.isPlaying)
            tentOne.Stop();
        //Stop Night AudioSource
        if (FrogNight.isPlaying)
            FrogNight.Stop();
        if (SkinnyNight.isPlaying)
            SkinnyNight.Stop();
        if (LocusNight.isPlaying)
            LocusNight.Stop();
        if (RattleNight.isPlaying)
            RattleNight.Stop();
        if (RainNight.isPlaying)
            RainNight.Stop();
        if (FlyNight.isPlaying)
            FlyNight.Stop();
        if (AcitveNight.isPlaying)
            AcitveNight.Stop();
        if (IntenseNight.isPlaying)
            IntenseNight.Stop();
        if (NightBase.isPlaying)
            NightBase.Stop();
        if (WoopWoop.isPlaying)
            WoopWoop.Stop();
        if (LightCricket.isPlaying)
            LightCricket.Stop();
        //Start Wave AudioSource
        if (!airSpry.isPlaying)
            airSpry.Play();
        if (!airyWaves.isPlaying)
            airyWaves.Play();
        if (!birdsWaves.isPlaying)
            birdsWaves.Play();
        if (!crashWaves.isPlaying)
            crashWaves.Play();
        if (!longSand.isPlaying)
            longSand.Play();
        if (!mediumFast.isPlaying)
            mediumFast.Play();
        if (!roarWave.isPlaying)
            roarWave.Play();
        if (!seaGulls.isPlaying)
            seaGulls.Play();
        //Stop Wind AudioSource
        if (backYard.isPlaying)
            backYard.Stop();
        if (windChimes.isPlaying)
            windChimes.Stop();
        if (windChirp.isPlaying)
            windChirp.Stop();
        if (windFour.isPlaying)
            windFour.Stop();
        if (windOne.isPlaying)
            windOne.Stop();
        if (windOwl.isPlaying)
            windOwl.Stop();
        if (windScuffle.isPlaying)
            windScuffle.Stop();
        if (windSix.isPlaying)
            windSix.Stop();
        if (windBirds.isPlaying)
            windBirds.Stop();
        if (windTwo.isPlaying)
            windTwo.Stop();
    }
    private void startWind()
    {
        //Stop Water AudioSource
        if (theBase.isPlaying)
            theBase.Stop();
        if (theDeep.isPlaying)
            theDeep.Stop();
        if (theShallow.isPlaying)
            theShallow.Stop();
        if (thePop.isPlaying)
            thePop.Stop();
        //Stop Rain AudioSource
        if (tinRoof.isPlaying)
            tinRoof.Stop();
        if (highRain.isPlaying)
            highRain.Stop();
        if (coveredRain.isPlaying)
            coveredRain.Stop();
        if (mediumRain.isPlaying)
            mediumRain.Stop();
        if (windowRain.isPlaying)
            windowRain.Stop();
        if (fullRain.isPlaying)
            fullRain.Stop();
        if (hardRain.isPlaying)
            hardRain.Stop();
        if (thunderOne.isPlaying)
            thunderOne.Stop();
        if (thunderTwo.isPlaying)
            thunderTwo.Stop();
        if (thunderThree.isPlaying)
            thunderThree.Stop();
        if (tentOne.isPlaying)
            tentOne.Stop();
        //Stop Night AudioSource
        if (FrogNight.isPlaying)
            FrogNight.Stop();
        if (SkinnyNight.isPlaying)
            SkinnyNight.Stop();
        if (LocusNight.isPlaying)
            LocusNight.Stop();
        if (RattleNight.isPlaying)
            RattleNight.Stop();
        if (RainNight.isPlaying)
            RainNight.Stop();
        if (FlyNight.isPlaying)
            FlyNight.Stop();
        if (AcitveNight.isPlaying)
            AcitveNight.Stop();
        if (IntenseNight.isPlaying)
            IntenseNight.Stop();
        if (NightBase.isPlaying)
            NightBase.Stop();
        if (WoopWoop.isPlaying)
            WoopWoop.Stop();
        if (LightCricket.isPlaying)
            LightCricket.Stop();
        //Stop Wave AudioSource
        if (airSpry.isPlaying)
            airSpry.Stop();
        if (airyWaves.isPlaying)
            airyWaves.Stop();
        if (birdsWaves.isPlaying)
            birdsWaves.Stop();
        if (crashWaves.isPlaying)
            crashWaves.Stop();
        if (longSand.isPlaying)
            longSand.Stop();
        if (mediumFast.isPlaying)
            mediumFast.Stop();
        if (roarWave.isPlaying)
            roarWave.Stop();
        if (seaGulls.isPlaying)
            seaGulls.Stop();
        //Start Wind AudioSource
        if (!backYard.isPlaying)
            backYard.Play();
        if (!windChimes.isPlaying)
            windChimes.Play();
        if (!windChirp.isPlaying)
            windChirp.Play();
        if (!windFour.isPlaying)
            windFour.Play();
        if (!windOne.isPlaying)
            windOne.Play();
        if (!windOwl.isPlaying)
            windOwl.Play();
        if (!windScuffle.isPlaying)
            windScuffle.Play();
        if (!windSix.isPlaying)
            windSix.Play();
        if (!windBirds.isPlaying)
            windBirds.Play();
        if (!windTwo.isPlaying)
            windTwo.Play();
    }

    private void runLoop(AudioMixer Mixer, AudioMixerSnapshot fileOff, AudioMixerSnapshot oneA, AudioMixerSnapshot twoA, AudioMixerSnapshot threeA, AudioMixerSnapshot fourA, AudioMixerSnapshot oneB, AudioMixerSnapshot twoB, AudioMixerSnapshot threeB, AudioMixerSnapshot fourB, AudioMixerSnapshot oneC, AudioMixerSnapshot twoC, AudioMixerSnapshot threeC, AudioMixerSnapshot fourC, AudioMixerSnapshot fiveC)
    {
        //Debug.Log("RunLoop just Started.");
        StartCoroutine(switchOne(Mixer, fileOff, oneA, twoA, threeA, fourA, oneB,  twoB, threeB, fourB, oneC, twoC, threeC, fourC, fiveC));
    }

    IEnumerator switchOne(AudioMixer Mixer, AudioMixerSnapshot fileOff,AudioMixerSnapshot oneA, AudioMixerSnapshot twoA, AudioMixerSnapshot threeA, AudioMixerSnapshot fourA, AudioMixerSnapshot oneB, AudioMixerSnapshot twoB, AudioMixerSnapshot threeB, AudioMixerSnapshot fourB, AudioMixerSnapshot oneC, AudioMixerSnapshot twoC, AudioMixerSnapshot threeC, AudioMixerSnapshot fourC, AudioMixerSnapshot fiveC)
    {
        Mixer.SetFloat(mixerVolume, masterVolume);
        if (iJustHitPlay == true)
        {
            fileOff.TransitionTo(0.0f);
            yield return new WaitForSeconds(0.0f);
            iJustHitPlay = false;
            //Debug.Log("I just hit Play!");
        }
        oneA.TransitionTo(3f);
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime/8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
            yield return new WaitForSeconds(holdTime/8);
            if (breakOut == true)
            {
                breakOut = false;
                yield break;
            }
            else
            oneC.TransitionTo(transTime);
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        else
            oneB.TransitionTo(transTime);
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        else
            twoA.TransitionTo(transTime);
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        else
            twoC.TransitionTo(transTime);
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        else
            twoB.TransitionTo(transTime);
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        else
            threeA.TransitionTo(transTime);
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        else
            threeC.TransitionTo(transTime);
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        else
            threeB.TransitionTo(transTime);
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        else
            fourA.TransitionTo(transTime);
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        else
            fourC.TransitionTo(transTime);
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        else
            fourB.TransitionTo(transTime);
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        else
            fiveC.TransitionTo(transTime);
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        yield return new WaitForSeconds(holdTime / 8);
        if (breakOut == true)
        {
            breakOut = false;
            yield break;
        }
        else
            //End of Loop
            oneA.TransitionTo(transTime);
        yield return new WaitForSeconds(transTime);
        if (fadeToggle.isOn == true)
        {
            if (masterVolume <= 30f)
                masterVolume = masterVolume - 3f;
            else
                Application.Quit();
        }
        if (cycleToggle.isOn == true)
        {
            holdTime = holdTime + (holdTime * .2f);
            transTime = .33f * holdTime;
        }
        runLoop(Mixer, fileOff, oneA, twoA, threeA, fourA, oneB, twoB, threeB, fourB, oneC, twoC, threeC, fourC, fiveC);
    }
}
