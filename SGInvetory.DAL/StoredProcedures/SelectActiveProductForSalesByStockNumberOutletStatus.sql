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
            INNER JOIN	productdetails 
            ON			productdetails.Code = DeliveryToOutletDetail.ProductDetail
            INNER JOIN	product
            ON			product.StockNumber = productdetails.Product
            WHERE		DeliveryToOutlet.Outlet = outletId
            AND			DeliveryToOutletDetail.Status = productStatus
            AND			DeliveryToOutletDetail.IsActive = 1
            AND			product.StockNumber = stockNumber
			GROUP BY	DeliveryToOutletDetail.ProductDetail
    )		AS			DTOD
    ON		PD.Code = DTOD.DTOD_ProductDetail
    LEFT JOIN
    (
			SELECT		SUM(Quantity) AS Sales_Quantity, ProductDetail AS Sales_ProductDetail
            FROM		sales
		    INNER JOIN	productdetails
            ON			sales.ProductDetail = productdetails.Code
            INNER JOIN	product
            ON			productdetails.Product = product.StockNumber
            WHERE		sales.Outlet = outletId   
            AND			product.StockNumber = stockNumber
			GROUP BY	ProductDetail
    )		AS		Sales
    ON		PD.Code = Sales.Sales_ProductDetail
    WHERE	
    PD.Product = stockNumber AND
    (DTOD.DTOD_Quantity - IFNULL(Sales.Sales_Quantity,0))>0;
END