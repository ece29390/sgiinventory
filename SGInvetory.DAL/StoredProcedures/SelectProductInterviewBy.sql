CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductInterviewBy`(IN stock VARCHAR(50))
BEGIN
SELECT 		pd.Code AS ProductDetailCode
			,pd.Product AS StockNumber
			,Color.Name AS ColorName
			,Washing.Name AS WashingName
			,Size.Name As SizeName			
			,IFNULL((DDetail.DDQuantity - IFNULL(DTOD.DTODQuantity,0)),0) AS Quantity
FROM		ProductDetails pd
LEFT JOIN	
(
	SELECT		SUM(Quantity) AS DDQuantity,ProductDetail AS DDCode
	FROM		DeliveryDetail
	WHERE		IsActive = 1
	GROUP BY 	ProductDetail
)	AS			DDetail
ON			pd.Code = DDetail.DDCode
LEFT JOIN
(
	SELECT		SUM(Quantity) AS DTODQuantity, DTOD.ProductDetail AS DTODCode
	FROM		DeliveryToOutletDetail 	DTOD
	WHERE		IsActive = 1
	GROUP BY	ProductDetail
)	AS			DTOD
ON			pd.Code = DTOD.DTODCode
INNER JOIN	Color	
ON			Color.Code = pd.Color
INNER JOIN	Washing
ON			Washing.Code = pd.Washing
INNER JOIN	Size
ON			Size.Code = pd.Size
where		pd.Product =stock
AND			pd.IsActive = 1;
END