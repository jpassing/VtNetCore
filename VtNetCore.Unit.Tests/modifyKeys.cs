using System.Text;
using VtNetCore.VirtualTerminal;
using VtNetCore.XTermParser;
using Xunit;

namespace VtNetCoreUnitTests
{
    public class ModifyKeys
    {
        private void Push(DataConsumer d, string s)
        {
            d.Push(Encoding.UTF8.GetBytes(s));
        }

        [Fact]
        public void SetModifyKeyboard()
        {
            var t = new VirtualTerminalController();
            t.Debugging = true;
            var d = new DataConsumer(t);

            Push(d, "".CSI() + ">0;8m");

            Assert.Equal(
                ModifyKeyboardMode.AllowModifySpecialKeys,
                t.ModifyKeyboard);
        }

        [Fact]
        public void SetModifyCursorKeys()
        {
            var t = new VirtualTerminalController();
            t.Debugging = true;
            var d = new DataConsumer(t);

            Push(d, "".CSI() + ">1;3m");

            Assert.Equal(
                ModifyCursorKeysMode.MarkAsPrivate,
                t.ModifyCursorKeys);
        }

        [Fact]
        public void SetModifyFunctionKeys()
        {
            var t = new VirtualTerminalController();
            t.Debugging = true;
            var d = new DataConsumer(t);

            Push(d, "".CSI() + ">2;1m");

            Assert.Equal(
                ModifyFunctionKeysMode.PrefixWithCsi,
                t.ModifyFunctionKeys);
        }

        [Fact]
        public void SetModifyOtherKeys()
        {
            var t = new VirtualTerminalController();
            t.Debugging = true;
            var d = new DataConsumer(t);

            Push(d, "".CSI() + ">4;1m");

            Assert.Equal(
                ModifyOtherKeysMode.EnabledWithExceptions,
                t.ModifyOtherKeys);
        }
    }
}
