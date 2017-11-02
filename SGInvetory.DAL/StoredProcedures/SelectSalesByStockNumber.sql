CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectSalesByStockNumber`(IN stockNumber varchar(50))
BEGIN
select 			sales.*
from 	 		sales
inner join		productdetails
on				sales.ProductDetail = productdetails.Code
inner join		product
on	binary		product.StockNumber = productdetails.Product
WHERE			product.StockNumber = stockNumber;
END