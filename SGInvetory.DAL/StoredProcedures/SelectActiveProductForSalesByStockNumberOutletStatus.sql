CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectActiveProductForSalesByStockNumberOutletStatus`(IN stockNumber varchar(50), IN outletId int, IN productStatus int)
BEGIN
	SELECT 				PD.*
    FROM			ProductDetails			PD   
    INNER JOIN
    (
			SELECT		SUM(DeliveryToOutletDetail.Quantity) AS DTOD_Quantity, DeliveryToOutletDetail.ProductDetail AS DTOD_ProductDetail
            FROM 		DeliveryToOutletDetail
            INNER JOIN	DeliveryToOutlet
            ON			DeliveryToOutletDetail.DeliveryToOutlet = DeliveryToOutlet.Id
            WHERE		DeliveryToOutlet.Outlet = outletId
            AND			DeliveryToOutletDetail.Status = productStatus
            AND			DeliveryToOutletDetail.IsActive = 1
    )		AS			DTOD
    ON		PD.Code = DTOD.DTOD_ProductDetail
    LEFT JOIN
    (
			SELECT		SUM(Quantity) AS Sales_Quantity, ProductDetail AS Sales_ProductDetail
            FROM		Sales
            WHERE		Outlet = outletId           
    )		AS		Sales
    ON		PD.Code = Sales.Sales_ProductDetail
    WHERE	
    PD.Product = stockNumber AND
    (DTOD.DTOD_Quantity - IFNULL(Sales.Sales_Quantity,0))>0;
END