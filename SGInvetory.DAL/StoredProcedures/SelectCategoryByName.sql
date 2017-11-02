CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectCategoryByName`(IN categoryName varchar(25))
BEGIN

   SELECT 		Id
				,Name
				,Description
				,CreatedDate
				,CreatedBy
				,ModifiedDate
				,ModifiedBy
	FROM		category
	WHERE		Name = categoryName;

END