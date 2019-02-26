/*
 * Author: D.Hall
 * Created: 8/7/18
*/


namespace KnightsWatch.Presentation.ViewModels
{
    public class BulletinBoardTabItemViewModel
    {
        public BulletinBoardViewModel BulletinBoardViewModel { get; set; }
        public BulletinBoardTabItemViewModel()
        {
            BulletinBoardViewModel = new BulletinBoardViewModel(null);
        }
    }
}
