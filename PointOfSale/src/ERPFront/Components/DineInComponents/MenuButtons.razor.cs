namespace ERPFront.Components.DineInComponents;

public partial class MenuButtons
{
    private void CreateDineInOrder()
    {
        _commonProperties!.CurrentDineInOrder!.BasicOrderDetails!.CashierName = _commonProperties.CurrentUser;
        _navigationManager.NavigateTo("/pos");
    }
}