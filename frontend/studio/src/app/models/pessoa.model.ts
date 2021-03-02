export interface Pessoa {
    cpf: string
    nome: string
    identidade: string
    endereco: string
    data_pagamento: string //Date
    inadimplente?: boolean
    tipo_pagamento?: string
    tipo_atividade?: string
    funcionario: boolean
    senha?: string
    tipo_pessoa: string
}