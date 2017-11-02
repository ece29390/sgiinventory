CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectDeliveryToOutletDetailByStockNumberAndOutletId`(IN stockNumber varchar(50),IN outlet int,IN productStatus int)
BEGIN
select 			deliverytooutletdetail.*
from 	 		deliverytooutletdetail
inner join		deliverytooutlet
on				deliverytooutletdetail.deliverytooutlet = deliverytooutlet.id
inner join		productdetails
on				deliverytooutletdetail.ProductDetail = productdetails.Code
inner join		product
on	binary		product.StockNumber = productdetails.Product
WHERE			product.StockNumber = stockNumber and deliverytooutlet.outlet = outlet
AND				deliverytooutletdetail.Status = productStatus;
END