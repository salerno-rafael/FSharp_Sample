module RsiStatusF

open System.Collections.Generic

let status:Dictionary<int, string> = new Dictionary<int, string>()
status.[1] <- "Pendente"
status.[2] <- "Válido"
status.[3] <- "Inválido"
status.[4] <- "Não Processado"
status.[5] <- "Processando"
status.[6] <- "Processado"
status.[7] <- "Erro De Validação"
status.[8] <- "Requer Ação"
status.[9] <- "Aprovado"
status.[10] <- "Não Aprovado"
status.[11] <- "Faturado"
status.[12] <- "Pago"
status.[13] <- "Cancelado"
status.[14] <- "Pronto Para Envio"
status.[15] <- "Requer Análise"
status.[16] <- "Anulado"
status.[16] <- "Anulado"
status.[17] <- "Aguardando Aprovação"