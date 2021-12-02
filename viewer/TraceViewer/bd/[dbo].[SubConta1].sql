USE [Producao]
GO

/****** Object:  View [dbo].[Subconta1]    Script Date: 23/10/2019 13:29:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER view [dbo].[Subconta1] AS  
  
/*  
CRIADA POR: Anonimo  
   DATA: Desconhecida  
  
ALT: Robinson Lourenco  
 EM: 04/04/2012  
OBJ: Ajuste para permitir a leitura dos itens contábeis (antigo CR) do IQ e a nova estrutura do Protheus  
  
ALT: Robinson Lourenço  
 EM: 15/10/2012  
OBJ:  Utilização do LinkedServer para o Banco do Protheus. Forçar collation SQL_Latin1_General_CP1_CI_AI pois collation no Protheus é Latin1_General_BIN    
  
ALT: Marcia Malta  
 EM: 09/01/2013  
OBJ: Alterar data fixa de: 20120101 para 20130101  
  
ALT: Vladimir  
 EM: 03/02/2015  
OBJ: Acréscimo do campo CTD_XDTFIM que é o novo campo que representa a Data Fim da SubConta1 no ERP.  

Por: Julio Cesar Oliveira (Inpartec)
Em:  11/06/2019
Obj: Inclusão do banco padrão (SDBPRD.dbo.) nos acessos as tabelas do ERP.

*/  
  
  
SELECT EMPRESA, CODSUB1, DESCSUB1, S1_VALINI, S1_VALFIM -- ALTERACAO, CLASSE_CEN, TIP_CLASSE,     
  FROM Subconta1_IQ WITH (NOLOCK)        
  
 UNION ALL  
  
SELECT CTD_FILIAL COLLATE SQL_Latin1_General_CP1_CI_AI AS Empresa,  
    CTD_ITEM COLLATE SQL_Latin1_General_CP1_CI_AI AS CodSub1,  
    CTD_DESC01 COLLATE SQL_Latin1_General_CP1_CI_AI AS DescSub1,  
  CASE  
    WHEN CTD_DTEXIS = ''  
     AND CTD_DTBLIN = ''  
     AND  CTD_BLOQ <> '1'  
   THEN CAST('20130101' AS DATETIME)      
    WHEN CTD_DTEXIS <=GETDATE()  
     AND CTD_DTEXSF >=GETDATE()  
   THEN CTD_DTEXIS  
    WHEN CTD_DTBLIN = ''  
     AND CTD_DTBLFI <> ''  
   THEN CAST('20130101' AS DATETIME)      
    WHEN CTD_DTBLIN <>''  
     AND CTD_DTBLFI = ''  
   THEN CTD_DTBLIN    
    WHEN CTD_DTBLIN <>''  
     AND CTD_DTBLFI <> ''  
   THEN CTD_DTBLFI -- considerar início de validade a data fim do bloqueio    
    WHEN CTD_BLOQ = '1'  
   THEN CAST('20130101' AS DATETIME)   
    WHEN CTD_DTBLIN = '' and CTD_DTBLFI = ''  
   THEN CAST('20130101' AS DATETIME)    
    ELSE CAST(NULL AS DATETIME)  
   END AS S1_VALINI ,     
  CASE            
    WHEN CTD_DTEXIS = ''  
     AND CTD_DTBLIN = ''  
     AND CTD_BLOQ <> '1'  
   THEN CAST(NULL AS SMALLDATETIME) --GETDATE()+1    
    WHEN CTD_DTEXIS <=GETDATE()  
     AND CTD_DTEXSF >=GETDATE()  
   THEN CTD_DTEXSF   
    WHEN CTD_DTBLIN = ''  
     AND CTD_DTBLFI <> ''  
   THEN CTD_DTBLFI    
    WHEN CTD_DTBLIN <>''  
     AND CTD_DTBLFI = ''  
   THEN CAST(NULL AS SMALLDATETIME) --GETDATE()+1    
    WHEN CTD_DTBLIN <>''   
     AND CTD_DTBLFI <> ''  
   THEN CTD_DTBLFI -- considerar início de validade a data fim do bloqueio    
    WHEN CTD_BLOQ = '1'  
   THEN CAST('20130102' AS DATETIME)  
    WHEN CTD_XDTFIM <=GETDATE()  
  AND CTD_XDTFIM <>''  
   THEN CTD_XDTFIM  
    ELSE CAST(NULL AS DATETIME)  
   END AS S1_VALFIM    
  -- SELECT *    
  FROM OPENQUERY([SRVSEDE01146],    
     'SELECT CTD_FILIAL, CTD_ITEM, CTD_DESC01, CTD_DTEXIS, CTD_DTBLIN, CTD_BLOQ, CTD_DTEXSF, CTD_XDTFIM, CTD_DTBLFI    
      FROM SDBPRD.dbo.CTD010 (nolock) ')    
  

GO


