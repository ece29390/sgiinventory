CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectDeliveryToOutletDetailByCodeOutletProductStatus`(IN productCode varchar(50),IN outletId int,IN productStatus int)
BEGIN
   SELECT			deliverytooutletdetail.*
   FROM				deliverytooutletdetail
   INNER JOIN		deliverytooutlet
   ON				deliverytooutletdetail.deliverytooutlet = deliverytooutlet.id
   WHERE			deliverytooutletdetail.ProductDetail = productCode
   AND				deliverytooutlet.Outlet = outletId
   AND				deliverytooutletdetail.Status = productStatus;
END