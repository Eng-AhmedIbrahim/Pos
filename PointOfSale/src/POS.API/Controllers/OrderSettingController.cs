﻿namespace POS.API.Controllers;

public class OrderSettingController : BaseApiController
{
    private readonly IOrderService _orderService;

    public OrderSettingController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("GetOrderSettings")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(List<OrderSetting>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<OrderSetting>>> GetOrderSettings()
    {
        var orderSettings = await _orderService.GetOrderSettingsAsync();
        return Ok(orderSettings);
    }

    [HttpGet("GetOrderSetting/{orderType}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(OrderSetting), StatusCodes.Status200OK)]
    public async Task<ActionResult<OrderSetting>> GetOrderSetting(OrderTypes orderType)
    {
        var orderSetting = await _orderService.GetOrderSettingAsync(orderType);
        return Ok(orderSetting);
    }

    [HttpPut("UpdateOrderSetting/{orderType}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(OrderSetting), StatusCodes.Status200OK)]
    public async Task<ActionResult<OrderSetting>> UpdateOrderSetting(OrderTypes orderType, [FromBody] OrderSetting orderSetting)
    {
         var result = await _orderService.UpdateOrderSettingAsync(orderType, orderSetting);
        return result is not null ? Ok(result) : NotFound(new ApiResponse(400));
    }
}
