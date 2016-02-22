using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Samples
{
    public class PickerBehavior : Behavior<Picker>
    {
        // Creating BindableProperties with Limited write access: http://iosapi.xamarin.com/index.aspx?link=M%3AXamarin.Forms.BindableObject.SetValue(Xamarin.Forms.BindablePropertyKey%2CSystem.Object) 

        public static readonly BindablePropertyKey SelectedItemPropertyKey = BindableProperty.CreateReadOnly("SelectedItem", typeof(string), typeof(PickerBehavior), default(string));

        public static readonly BindableProperty SelectedItemProperty = SelectedItemPropertyKey.BindableProperty;

        public string SelectedItem
        {
            get { return (string)base.GetValue(SelectedItemProperty); }
            private set { base.SetValue(SelectedItemPropertyKey, value); }
        }


        protected override void OnAttachedTo(Picker bindable)
        {
            bindable.SelectedIndexChanged += bindable_SelectedIndexChanged;
        }

        void bindable_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            if (picker.SelectedIndex <= 0 || picker.SelectedIndex > picker.Items.Count - 1)
                SelectedItem = null;
            else
                SelectedItem=picker.Items[picker.SelectedIndex];
        }

        protected override void OnDetachingFrom(Picker bindable)
        {
            bindable.SelectedIndexChanged -= bindable_SelectedIndexChanged;
        }
    }
}
