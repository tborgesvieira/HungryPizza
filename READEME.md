Teste Backend

Você acabou de ser contratado como desenvolvedor da Hungry Pizza. Esta é uma pizzaria muito famosa no bairro, seus donos sempre foram muito reticentes quando o assunto é a venda online, mas diante das circunstâncias recentes eles tiveram de reconsiderar. Seu desafio é criar uma API para receber os pedidos feitos à partir do site da pizzaria que atenda aos requisitos abaixo:

# Obrigatórios

- A aplicação deve ser construida com C#
- A api deve rodar em ambiente Linux, por isso é necessário que seja construída com .NET Core
- Endpoint que registra um pedido
    - Todo pedido precisa ter um identificador único, o sistema deve gerar um e no caso de sucesso o endpoint deve retorná-lo
    - Um pedido pode ter no mínimo uma pizza e no máximo 10.
    - Cada pizza pode ter até dois sabores.
    - O preço da pizza com dois sabores deve ser composto pela média dos valores.
    - O cliente não precisa ter cadastro para fazer um pedido, mas nesse caso precisará informar os dados de endereço de entrega. Caso seja um cliente cadastrado ele não precisa informar o endereço de entrega, pois deve constar em seu cadastro.
    - Não vamos cobrar frete nessa primeira versão do sistema
    - Sabores podem estar em falta. Caso isso aconteça, o endpoint deve rejeitar o pedido e indicar o erro.
- Endpoint que lista pedidos
    - apenas para clientes que tem cadastro, deve receber o identificador do mesmo
    - deve fornecer identificador do pedido, data/hora em que o pedido foi feito, quantidade de pizzas e valor total
    - o endpoint deve suportar paginação (ordenação do pedido mais recente para o mais antigo)
- Testes de unidade
    - como e o que testar, e com quais bibliotecas, fica a critério do que achar mais apropriado

# Desejáveis

- Testes de integração
    - como e o que testar, e com quais bibliotecas, fica a critério do que achar mais apropriado

# Informações adicionais

- Apesar de ser um teste simples desejamos ver o que o candidato entende ser o melhor, o "estado da arte", em termos de desenvolvimento de software. Pedimos que capriche o máximo que conseguir.
- A definição do banco de dados utilizado fica a critério do candidato, assim como bibliotecas e frameworks.
- Os sabores disponíveis são: 3 Queijos (R$ 50), Frango com requeijão (R$ 59.99), Mussarela (R$ 42.50), Calabresa (R$ 42.50), Pepperoni (R$ 55), Portuguesa (R$ 45), Veggie (R$ 59.99)
    - os sabores podem ser cadastrados da forma que for mais conveniente (carga no banco, endpoint, etc)
- Os clientes da pizzaria podem ser cadastrados da forma que for mais conveniente (carga no banco, endpoint, etc)

- Esperamos que você resolva o teste em até 2 dias a contar do próximo dia útil após o recebimento do teste. Caso precise de mais tempo, por favor, avise-nos com até 1 dia de antecedência a contar do recebimento.
- Ao final do prazo limite ou quando você terminar, o que acontecer primeiro, você deve publicar o código desenvolvido em um repositório aberto no GitHub e, depois, responder a este e-mail com o link para o repositório.
