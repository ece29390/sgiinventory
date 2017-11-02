CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectSupplierByName`(IN supplierName VARCHAR(100))
BEGIN

   SELECT Id,
		  Name,
		  Address,
		  CreatedBy,
		  CreatedDate,
	      ModifiedBy,
		  ModifiedDate
	FROM supplier
	WHERE Name = supplierName;


END