USE [Producao]
GO

/****** Object:  View [dbo].[Centros]    Script Date: 22/10/2019 16:35:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER view [dbo].[Centros] as    
/*    
  Criada por: Anonimo    
  Data:   Desconhecida    
                                                                                                                                                                                                                                                               
  Alt: Alan Reis    
  Em: 09/05/2012    
  Obj: Ajuste para permitir a leitura dos centros (antig Centros) do IQ e a nova estrutura do Protheus     
      
  Alt: Robinson Lourenço    
  Em: 11/10/2012    
  Obj:  Utilização do LinkedServer para o Banco do Protheus,     
  Forçar collation SQL_Latin1_General_CP1_CI_AI pois collation no Protheus é Latin1_General_BIN    
  
  Alt: Daniela Richter  
  Em: 01/07/2014    
  Obj:  não buscar os centro de custo deletados     
*/                                                                                                                                                                                                                                                             
  
  
  
    
                                                                                                                                                                                                                                                              
SELECT  EMPRESA, CENTRO, NOMECENTRO, CENTRO_ASS, CENTRO_LAN, ORDENACAO,                                                                                                                                                                                        
        FLAG_IMP, ALTERACAO, CLASSE_CEN, CE_VALINI, CE_VALFIM, TIP_CLASSE,                                                                                                                                                                                     
		FLG_RECLANC_CAP, OBS_CENTRO, NOM_RESP_CENTRO, DAT_BLOQUEIO                                                                                                                                                                                                
  FROM  Centros_IQ                                                                                                                                                                                                                                             
  
  
--    select * from OPENQUERY([srvsede0113\iqprod],'SELECT * FROM iqprod.dbo.Centros')--  with (nolock) -- 1625                                                                                                                                                
  
           
UNION ALL    

SELECT  CTT_FILIAL COLLATE SQL_Latin1_General_CP1_CI_AI as EMPRESA, CTT_CUSTO COLLATE SQL_Latin1_General_CP1_CI_AI as CENTRO, CTT_DESC01 COLLATE SQL_Latin1_General_CP1_CI_AI as NOMECENTRO,    
   NULL CENTRO_ASS, NULL CENTRO_LAN, NULL ORDENACAO,      
        NULL FLAG_IMP, NULL ALTERACAO, NULL CLASSE_CEN, CAST('20120101' as datetime) CE_VALINI, NULL CE_VALFIM, NULL TIP_CLASSE,              
     NULL FLG_RECLANC_CAP, NULL OBS_CENTRO, NULL NOM_RESP_CENTRO, NULL DAT_BLOQUEIO                                
  FROM  OPENQUERY([srvsede01146],'SELECT CTT_FILIAL , CTT_CUSTO , CTT_DESC01 FROM SDBPRD.dbo.CTT010
			WHERE D_E_L_E_T_ <> ''*''')    
  -- select * from OPENQUERY([srvsede01146],'SELECT * FROM SDBHML.dbo.CTT010')    
  -- EXECUTE (@cmdSQL) AT srvsede01146    
  -- select * from Centros    
  
GO


