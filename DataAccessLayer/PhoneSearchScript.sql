
    DECLARE @RegionCode VARCHAR='001'; 
    DECLARE @AraCode VARCHAR='0216';
    DECLARE @PhoneNumber VARCHAR='261 4357';

select Pn.* from INF.PhoneNumber as Pn INNER Join INF.Region as Rg ON(Pn.RegionCode=rg.Code)
  Where rg.Code=@RegionCode AND 
        Pn.PhoneNumber=@PhoneNumber AND 
        Pn.AreaCode=@AraCode
 
