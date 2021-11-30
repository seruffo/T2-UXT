USE [Producao]
GO

/****** Object:  View [dbo].[Planocta]    Script Date: 23/10/2019 13:33:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER view [dbo].[Planocta] as -- select top 10 * from Planocta
/*  
  Criada por: Anonimo  
  Data:   Desconhecida  
                                                                                                                                                                                                                                                             
     
  Alt: Robinson Lourenço  
  Em: 15/10/2012  
  Obj:  Utilização do LinkedServer para o Banco do Protheus,   
  Forçar collation SQL_Latin1_General_CP1_CI_AI pois collation no Protheus é Latin1_General_BIN  
*/                                                                                                                                                                                                                                                             


  
  
  
  
SELECT EMPRESA, CONTA,  NOMECONTA ,  cast('19000101' as datetime) as DAT_VALID_INI, cast('20111231' as datetime) as DAT_VALID_FIM   
  from Planocta_IQ   
   where left(CONTA ,1) = '4' and LEN(CONTA)>=11  
  union all   
select  CT1_FILIAL COLLATE SQL_Latin1_General_CP1_CI_AI as Empresa, CT1_CONTA COLLATE SQL_Latin1_General_CP1_CI_AI as Conta,   
  CT1_DESC01 COLLATE SQL_Latin1_General_CP1_CI_AI as NOMECONTA,  
  Case   
     when CT1_DTEXIS = '' and CT1_DTBLIN = '' and  CT1_BLOQ <> '1' then cast('20120101' as datetime)    
     when CT1_DTEXIS <=GETDATE() and  CT1_DTEXSF >=GETDATE() then CT1_DTEXIS   
     when CT1_DTBLIN = '' and CT1_DTBLFI <> '' then cast('20120101' as datetime)    
     when CT1_DTBLIN <>'' and CT1_DTBLFI = '' then CT1_DTBLIN  
     when CT1_DTBLIN <>''and  CT1_DTBLFI <> '' then  CT1_DTBLFI -- considerar início de validade a data fim do bloqueio  
     when CT1_BLOQ = '1' then cast('20120101' as datetime)  
     when CT1_DTBLIN = '' and CT1_DTBLFI = '' then cast('20120101' as datetime)   
     else cast(null as datetime)   
  end DAT_VALID_INI ,   
  Case   
     when CT1_DTEXIS = '' and CT1_DTBLIN = '' and  CT1_BLOQ <> '1' then cast(null as smalldatetime) --GETDATE()+1  
     when CT1_DTEXIS <=GETDATE() and  CT1_DTEXSF >=GETDATE() then CT1_DTEXSF   
     when CT1_DTBLIN = '' and CT1_DTBLFI <> '' then CT1_DTBLFI  
     when CT1_DTBLIN <>'' and CT1_DTBLFI = '' then cast(null as smalldatetime) --GETDATE()+1  
     when CT1_DTBLIN <>''and  CT1_DTBLFI <> '' then  CT1_DTBLFI -- considerar início de validade a data fim do bloqueio  
     when CT1_BLOQ = '1' then cast('20120102' as datetime)  
     else cast(null as datetime)   
  end DAT_VALID_FIM       
  FROM  OPENQUERY([LNK_ERP],  
     'SELECT CT1_FILIAL , CT1_CONTA , CT1_DESC01, CT1_DTEXIS, CT1_DTBLIN, CT1_BLOQ, CT1_DTEXSF, CT1_DTBLFI  
      FROM SDBPRD.dbo.CT1010 (nolock) where left(CT1_CONTA ,1) = ''4'' and LEN(CT1_CONTA)>=11')  
          
/*SELECT EMPRESA, CONTA, DIGCONTA, NOMECONTA, CODIGORED, DIGITORED, CODIGOPERM,   
       TIPOCONTA, NOMENADIC, BLOQUEIO, PLACENTRO, LANCAINDEX,   
       ALTERNA01, ALTERNA02, ALTERNA03, CORRELA01, CORRELA02, CORRELA03, CORRELA04,  
       ALTERACAO, OBRIGSUB1, OBRIGSUB2, SUMARIA, FLG_RECLANC_CAP, DAT_BLOQUEIO,   
       TIQ_LANCOM, CODTIP, COD_GRUPO, FLG_IMPOSTO, FLG_CTRL_SUBS, CTA_SPED, SPED_NAT_CONTA, DT_DAT_ATUALIZA  
    from OPENQUERY([srvsede0113\iqprod],'SELECT * FROM iqprod.dbo.Planocta')-- IQ with (nolock) -- 9819  
*/ 


GO


