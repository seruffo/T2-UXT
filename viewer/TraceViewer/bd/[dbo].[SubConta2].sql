USE [Producao]
GO

/****** Object:  View [dbo].[Subconta2]    Script Date: 23/10/2019 13:26:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER view [dbo].[Subconta2] AS  
  
/*  
  CRIADA POR: Anonimo  
     DATA: Desconhecida  
  
ALTERADO POR: Robinson Lourenco  
    EM: 04/04/2012  
 OBJETIVO: Ajuste para permitir a leitura das classes de valor (antiga sub2) do IQ e a nova estrutura do Protheus  
  
ALTERADO POR: Robinson Lourenço  
    EM: 15/10/2012  
 OBJETIVO: Utilização do LinkedServer para o Banco do Protheus,  
     Forçar collation SQL_Latin1_General_CP1_CI_AI pois collation no Protheus é Latin1_General_BIN  
  
ALTERADO POR: Marcia Malta  
    EM: 09/01/2013  
 OBJETIVO: Alterar data fixa de: 20120101 para 20130101  
  
ALTERADO POR: Vladimir  
    EM: 13/05/2013  
 OBJETIVO: Alterado para trazer SubConta2 de todas as filiais.   
  
ALTERADO POR: Vladimir  
    EM: 03/02/2015  
 OBJETIVO: Acréscimo do campo CTH_XDTFIM que é o novo campo que representa a Data Fim da SubConta1 no ERP.     

Por: Julio Cesar Oliveira (Inpartec)
Em:  11/06/2019
Obj: Inclusão do banco padrão (SDBPRD.dbo.) nos acessos as tabelas do ERP.

*/    
    
SELECT EMPRESA, CODSUB2, DESCSUB2, S2_VALINI, S2_VALFIM     
  FROM Subconta2_IQ WITH (NOLOCK)  
  
 UNION ALL  
  
SELECT CTH_FILIAL COLLATE SQL_Latin1_General_CP1_CI_AI AS Empresa, CTH_CLVL COLLATE SQL_Latin1_General_CP1_CI_AI AS CodSub2,  
    CTH_DESC01 COLLATE SQL_Latin1_General_CP1_CI_AI AS DescSub2,  
  CASE  
    WHEN CTH_DTEXIS = '' AND CTH_DTBLIN = '' AND  CTH_BLOQ <> '1' THEN CAST('20130101' AS DATETIME)  
    WHEN CTH_DTEXIS <= GETDATE() AND CTH_DTEXSF = '' THEN CTH_DTEXIS  
    WHEN CTH_DTEXIS <= GETDATE() AND CTH_DTEXSF >= GETDATE() THEN CTH_DTEXIS  
    WHEN CTH_DTBLIN = '' AND CTH_DTBLFI <> '' THEN CAST('20130101' AS DATETIME)  
    WHEN CTH_DTBLIN <>'' AND CTH_DTBLFI = '' THEN CTH_DTBLIN  
    WHEN CTH_DTBLIN <>'' AND  CTH_DTBLFI <> '' THEN  CTH_DTBLFI -- considerar início de validade a data fim do bloqueio  
    WHEN CTH_DTEXIS = '' AND  CTH_DTBLFI = '' THEN CAST('20130101' AS DATETIME)  
    WHEN CTH_BLOQ = '1' THEN CAST('20130101' AS DATETIME)  
    ELSE CAST(NULL AS DATETIME)  
   END AS S1_VALINI,  
  CASE  
    WHEN CTH_DTEXIS = '' AND CTH_DTBLIN = '' AND  CTH_BLOQ <> '1' THEN CAST(NULL AS SMALLDATETIME) --GETDATE()+1  
    WHEN CTH_DTEXIS <= GETDATE() AND CTH_DTEXSF >= GETDATE() THEN CTH_DTEXSF  
    WHEN CTH_DTBLIN = '' AND CTH_DTBLFI <> '' THEN CTH_DTBLFI  
    WHEN CTH_DTBLIN <>'' AND CTH_DTBLFI = '' THEN CAST(NULL AS SMALLDATETIME) --GETDATE()+1  
    WHEN CTH_DTBLIN <>''AND  CTH_DTBLFI <> '' THEN  CTH_DTBLFI -- considerar início de validade a data fim do bloqueio  
    WHEN CTH_BLOQ = '1' THEN CAST('20130102' AS DATETIME)  
    WHEN CTH_XDTFIM <=GETDATE() AND CTH_XDTFIM <>'' THEN CTH_XDTFIM  
    ELSE CAST(NULL AS DATETIME)  
   END AS S2_VALFIM  
   --SELECT CTH_DTEXSF,*  
  FROM OPENQUERY([SRVSEDE01146],  
 'SELECT CTH_FILIAL, CTH_CLVL, CTH_DESC01, CTH_DTEXIS, CTH_DTBLIN, CTH_BLOQ, CTH_DTEXSF, CTH_XDTFIM, CTH_DTBLFI  
    FROM SDBPRD.dbo.CTH010') -- where CTH_FILIAL = ''01RJ''')  == Comentado para trazer todas as filiais  
      
  

GO


