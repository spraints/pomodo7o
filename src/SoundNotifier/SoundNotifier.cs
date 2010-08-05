using System.Media;
using Pomodo7o;

namespace SoundNotifier
{
    public class SoundNotifier : BasePublisher
    {
        public override void RestComplete()
        {
            SystemSounds.Exclamation.Play();
        }

        public override void WorkComplete()
        {
            SystemSounds.Exclamation.Play();
        }
    }
}
