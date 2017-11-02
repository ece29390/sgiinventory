CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectOutletByName`(IN outletName VARCHAR(25))
BEGIN
  
   SELECT Id,
		  Name,
		  Address,
		  CreatedBy,
		  CreatedDate,
	      ModifiedBy,
		  ModifiedDate
	FROM outlet
	WHERE Name = outletName;

END