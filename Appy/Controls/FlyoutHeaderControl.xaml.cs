using Appy.Models;

namespace Appy.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();

        if (App.UserDetails != null)
        {
			lblUserName.Text = App.UserDetails.Username;
            imgAvatar.ImageSource = App.UserDetails.Avatar??Icons.Profile;
        }
    }
}