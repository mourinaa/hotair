CREATE PROCEDURE [dbo].[p_UTIL_HotAirProductRate]
AS
BEGIN


INSERT INTO [CONFDB].[dbo].ProductRateValue (
        ProductRateID, SellRate, SellRateCurrencyID, BuyRate, BuyRateCurrencyID, DefaultOption, WholesalerID, CustomerID
        )
SELECT prv.ProductRateID, prv.SellRate, prv.SellRateCurrencyID, prv.BuyRate, prv.BuyRateCurrencyID, 0 as DefaultOption, '0000000001' as WholesalerID, c.ID FROM dbo.ProductRateValue prv 
RIGHT OUTER Join  dbo.Customer c ON prv.CustomerID != c.ID 
WHERE c.CreatedDate > '2023-03-10 00:00:00' AND c.CreatedDate  < '2023-03-12 00:00:00' AND prv.SellRateCurrencyID = 'AUD'
AND prv.DefaultOption = 1
AND NOT EXISTS(SELECT prv.CustomerID
               FROM [CONFDB].[dbo].[ProductRateValue] prv
               WHERE prv.CustomerID = c.ID) 


END