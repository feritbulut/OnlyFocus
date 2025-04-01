using System.Timers;
using Plugin.Maui.Audio;
namespace OnlyFocus
{
    public partial class MainPage : ContentPage
    {
        private int minutes = 25;
        private int remainingSeconds;
        private System.Timers.Timer timer;
        IAudioPlayer playerain;
        bool isPlayingrain = false;
        IAudioPlayer playerwave;
        bool isPlayingwave = false;
        IAudioPlayer playerwind;
        bool isPlayingwind = false;
        IAudioPlayer playerbird;
        bool isPlayingbird = false;
        IAudioPlayer playerbowl;
        bool isPlayingbowl = false;
        IAudioPlayer playergrass;
        bool isPlayingrass = false;
        IAudioPlayer playerriver;
        bool isPlayingriver = false;
        IAudioPlayer playerfire;
        bool isPlayingfire = false;
        IAudioPlayer playersignal;
        bool isPlayingsignal = false;
        IAudioPlayer playersong;
        bool isPlayingsong = false;
        private bool isTreeRotating = false;
        private Animation treeRotation;

        public MainPage()
        {
            InitializeComponent();
            LoadAudio();
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += TimerElapsed;
            musicslider.Value = 5;
            remainingSeconds = minutes * 60; 
            UpdateTimeDisplay();
        }

        private async void LoadAudio()
        {
            playersignal = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("white.mp3"));
            playersignal.Loop = true;

            playerfire = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("firer.mp3"));
            playerfire.Loop = true;

            playerriver = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("riverr.mp3"));
            playerriver.Loop = true;

            playergrass = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("grasss.mp3"));
            playergrass.Loop = true;

            playerbowl = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("bowl.mp3"));
            playerbowl.Loop = true;

            playerbird = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("bird.mp3"));
            playerbird.Loop = true;

            playerain = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("rainsound.mp3"));
            playerain.Loop = true;

            playerwave = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("wave.mp3"));
            playerwave.Loop = true;

            playerwind = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("wind.mp3"));
            playerwind.Loop = true;

            playersong = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("song.mp3"));
            playersong.Loop = true;
        }

        private void rainsoundchanged(object sender, ValueChangedEventArgs e)
        {
            double volume = e.NewValue / 10.0; // Slider 0-10 arası, sesi 0-1 arasına ölçekle
            

            if (volume == 0)
            {
                playerain.Stop();
                isPlayingrain = false;
            }
            else
            {
                if (!isPlayingrain)
                {
                    playerain.Play();
                    isPlayingrain = true;
                }

                playerain.Volume = volume; // Ses seviyesini ayarla
            }
        }
        private void wavesoundchanged(object sender, ValueChangedEventArgs e)
        {
            double volume = e.NewValue / 10.0; // Slider 0-10 arası, sesi 0-1 arasına ölçekle


            if (volume == 0)
            {
                playerwave.Stop();
                isPlayingwave = false;
            }
            else
            {
                if (!isPlayingwave)
                {
                    playerwave.Play();
                    isPlayingwave = true;
                }

                playerwave.Volume = volume; // Ses seviyesini ayarla
            }
        }

        private void windsoundchanged(object sender, ValueChangedEventArgs e)
        {
            double volume = e.NewValue / 10.0; // Slider 0-10 arası, sesi 0-1 arasına ölçekle


            if (volume == 0)
            {
                playerwind.Stop();
                isPlayingwind = false;
            }
            else
            {
                if (!isPlayingwind)
                {
                    playerwind.Play();
                    isPlayingwind = true;
                }

                playerwind.Volume = volume; // Ses seviyesini ayarla
            }
        }

        private void birdsoundchanged(object sender, ValueChangedEventArgs e)
        {
            double volume = e.NewValue / 10.0; // Slider 0-10 arası, sesi 0-1 arasına ölçekle       
            if (volume == 0)
            {
                playerbird.Stop();
                isPlayingbird = false;
            }
            else
            {
                if (!isPlayingbird)
                {
                    playerbird.Play();
                    isPlayingbird = true;
                }
                playerbird.Volume = volume; // Ses seviyesini ayarla
            }

        }

        private void bowlsoundchanged(object sender, ValueChangedEventArgs e)
        {
            double volume = e.NewValue / 10.0; // Slider 0-10 arası, sesi 0-1 arasına ölçekle
            if (volume == 0)
            {
                playerbowl.Stop();
                isPlayingbowl = false;
            }
            else
            {
                if (!isPlayingbowl)
                {
                    playerbowl.Play();
                    isPlayingbowl = true;
                }
                playerbowl.Volume = volume; // Ses seviyesini ayarla
            }
        }

        private void grasssoundchanged(object sender, ValueChangedEventArgs e)
        {
            double volume = e.NewValue / 10.0; // Slider 0-10 arası, sesi 0-1 arasına ölçekle
            if (volume == 0)
            {
                playergrass.Stop();
                isPlayingrass = false;
            }
            else
            {
                if (!isPlayingrass)
                {
                    playergrass.Play();
                    isPlayingrass = true;
                }
                playergrass.Volume = volume; // Ses seviyesini ayarla
            }
        }

        private void riversoundchanged(object sender, ValueChangedEventArgs e)
        {
            double volume = e.NewValue / 10.0; // Slider 0-10 arası, sesi 0-1 arasına ölçekle
            if (volume == 0)
            {
                playerriver.Stop();
                isPlayingriver = false;
            }
            else
            {
                if (!isPlayingriver)
                {
                    playerriver.Play();
                    isPlayingriver = true;
                }
                playerriver.Volume = volume; // Ses seviyesini ayarla
            }
        }

        private void firesoundchanged(object sender, ValueChangedEventArgs e)
        {
            double volume = e.NewValue / 10.0; // Slider 0-10 arası, sesi 0-1 arasına ölçekle
            if (volume == 0)
            {
                playerfire.Stop();
                isPlayingfire = false;
            }
            else
            {
                if (!isPlayingfire)
                {
                    playerfire.Play();
                    isPlayingfire = true;
                }
                playerfire.Volume = volume; // Ses seviyesini ayarla
            }
        }

        private void signalsoundchanged(object sender, ValueChangedEventArgs e)
        {
            double volume = e.NewValue / 10.0; // Slider 0-10 arası, sesi 0-1 arasına ölçekle
            if (volume == 0)
            {
                playersignal.Stop();
                isPlayingsignal = false;
            }
            else
            {
                if (!isPlayingsignal)
                {
                    playersignal.Play();
                    isPlayingsignal = true;
                }
                playersignal.Volume = volume; // Ses seviyesini ayarla
            }
        }

        private void IncreaseMinute(object sender, EventArgs e)
        {
            minutes += 5;
            remainingSeconds = minutes * 60;
            UpdateTimeDisplay();
        }

        private void DecreaseMinute(object sender, EventArgs e)
        {
            if (minutes > 5)
            {
                minutes -= 5;
                remainingSeconds = minutes * 60;
                UpdateTimeDisplay();
            }
        }

        private void StartTimer(object sender, EventArgs e)
        {
            if (remainingSeconds <= 0)
                remainingSeconds = minutes * 60;

            timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (remainingSeconds > 0)
            {
                remainingSeconds--;
                Dispatcher.Dispatch(UpdateTimeDisplay);
            }
            else
            {
                timer.Stop();
                Dispatcher.Dispatch(async () =>
                {
                    await DisplayAlert("The Time Is Up", "Congratulations, you have completed the countdown.!", "OK");
                });
            }
        }

        private void ResetTimer(object sender, EventArgs e)
        {
            timer.Stop();
            minutes = 25;
            remainingSeconds = minutes * 60;
            UpdateTimeDisplay();
        }

        private void UpdateTimeDisplay()
        {
            int displayMinutes = remainingSeconds / 60;
            int displaySeconds = remainingSeconds % 60;
            TimerLabel.Text = $"{displayMinutes:00}:{displaySeconds:00}";
        }

        private void musicPlay(object sender, EventArgs e)
        {
            ImageButton musicButton = (ImageButton)sender;

            if (!isPlayingsong)
            {
                
                musicButton.Source = "pause.png";

                
                playersong.Play();
                isPlayingsong = true;

                
                StartTreeRotation();
            }
            else
            {
                
                musicButton.Source = "play1.png";

               
                playersong.Pause();
                isPlayingsong = false;

                
                StopTreeRotation();
            }
        }

        private void musicvalue(object sender, ValueChangedEventArgs e)
        {
            double volume = e.NewValue / 10.0;

            if (playersong != null)
            {
                playersong.Volume = volume;
            }
        }

        private void StartTreeRotation()
        {
            if (isTreeRotating)
                return;

            isTreeRotating = true;

            
            var treeImage = this.FindByName<Image>("treeImage");

            
            treeRotation = new Animation(
                callback: v => treeImage.Rotation = v,
                start: 0,
                end: 360,
                easing: Easing.Linear
            );

           
            treeRotation.Commit(
                owner: this,
                name: "TreeRotation",
                length: 7000,
                rate: 16,
                repeat: () => isTreeRotating
            );
        }

        private void StopTreeRotation()
        {
            if (!isTreeRotating)
                return;

            isTreeRotating = false;
            this.AbortAnimation("TreeRotation");
        }
    }

}
