# Locadora 
Api Locadora criada utilizando .Net 8/C#,  Sql Server utilizando o EntityFrameWorkCore para mapear e conectar, Autorização via JWT Bearer, o servidor e a aplicação foram publicadas no Azure.

Foi criado baseado na estrutura Code First utilizando migrations.

Utilizando injeção de dependência.

Buscando deixar o código mais legível e limpo.

Segue o link com Swagger.

https://locadora-api.azurewebsites.net/swagger/index.html

Com objetivo de buscar soluções para o negócio de locação de veículos, essa api foi desenvolvida pensando no domínio "Locação" logo o objetivo de uma locadora é alugar Carros.

A aplicação consiste em Cadastrar funcionários que serão os usuários padrão do sistema, os usuários são controlados por roles do JWT onde algumas funcionalidades não são permitidas.
Existe um usuário master que é o responsável por implantar uma nova Locadora.

Segue usuário master do sistema.

Usuario: admin 

Senha: admin

No caso dos usuários admin com cargo de confiança tem acesso a quase todas as funcionalidades, não sendo permitido apenas adicionar e visualizar informações de outras locadoras.
Todas as requisições com excessão a Api de Authentication é controlado por Token JWT Bearer.

Com usuário cadastrado e login realizado "Informar 'Bearer ' antes de colar o Token" podemos cadastrar veículos, clientes e realizar locações.

As locações são realizadas com um vínculo entre veículo e cliente alterando a disponibilidade do veículo, com uma data informada baseada no dia previsto para retirada e a entrega é feita em tempo real, cobrando multa no valor de 20% quando ultapassar o dia da entrega.

Quando entregue o veículo retorna novamente a sua disponilidade.

As funcionalidas da aplicação são:

Api:

  Authentication:
  
    Post https://locadora-api.azurewebsites.net/Api/Authentication/Login
    
    Segue o json logar:
  
    {
      "usuario": "admin",
      "senha": "admin"
    }
    
  Usuario:
  
     Post https://locadora-api.azurewebsites.net/Api/Usuario/
     
     Put https://locadora-api.azurewebsites.net/Api/Usuario/{id}
     
     Delete https://locadora-api.azurewebsites.net/Api/Usuario/{id}
     
     Get https://locadora-api.azurewebsites.net/Api/Usuario/{id}
     
     Get https://locadora-api.azurewebsites.net/Api/Usuario/BuscaCompleta
     
     Put https://locadora-api.azurewebsites.net/Api/Usuario/DefinirAdministrador/{id}
     
    Segue o json para adicionar e editar:
    {
      "nomeUsuario": "string",
      "senha": "string",
      "locadoraModeloId": 0,
      "codigoAdministrador": "string"
    }
    
  Veiculo:
  
    Post https://locadora-api.azurewebsites.net/Api/Veiculo/
    
    Put https://locadora-api.azurewebsites.net/Api/Veiculo/{id}
    
    Delete https://locadora-api.azurewebsites.net/Api/Veiculo/{id}
    
    Get https://locadora-api.azurewebsites.net/Api/Veiculo/{id}
    
    Get https://locadora-api.azurewebsites.net/Api/Veiculo/BuscaCompleta/{idLocadora}
      
    Segue o json para adicionar e editar:
    {
      "marca": "string",
      "modelo": "string",
      "ano": 0,
      "cor": "string",
      "placa": "string",
      "valorDiaria": 0,
      "locadoraModeloId": 0
    }
    
    {
      "marca": "string",
      "modelo": "string",
      "ano": 0,
      "cor": "string",
      "placa": "string"
    }
    
  Cliente:
  
    Post https://locadora-api.azurewebsites.net/Api/Cliente/
    
    Put https://locadora-api.azurewebsites.net/Api/Cliente/{id}
    
    Delete https://locadora-api.azurewebsites.net/Api/Cliente/{id}
    
    Get https://locadora-api.azurewebsites.net/Api/Cliente/{id}
    
    Get https://locadora-api.azurewebsites.net/Api/Cliente/BuscaCompleta/{idLocadora}
  
    Put https://locadora-api.azurewebsites.net/Api/Cliente/Bloquear/{id}
  
    Put https://locadora-api.azurewebsites.net/Api/Cliente/Desbloquear/{id}

    Segue o json para adicionar e editar:
    {
      "nome": "string",
      "cpf": "string",
      "rg": "string",
      "enedereco": "string",
      "telefone": "string",
      "email": "string",
      "idLocadora": 0
    }

    {
      "enedereco": "string",
      "telefone": "string",
      "email": "string"
    }

  Locacao:
  
    Post https://locadora-api.azurewebsites.net/Api/Locacao/Alugar
    
    Get https://locadora-api.azurewebsites.net/Api/Locacao/{id}
    
    Put https://locadora-api.azurewebsites.net/Api/Locacao/Entregar{id}

    Get https://locadora-api.azurewebsites.net/Api/Locacao/BuscaCompleta/{idLocadora}

    Segue o json para alugar:
    {
      "dataRetirada": "2024-01-23T04:30:29.962Z",
      "clienteId": 0,
      "veiculoId": 0,
      "locadoraModeloId": 0,
      "quantidadeDiarias": 0,
      "observacao": "string"
    }

    Melhorias que podem ser realizadas:
    
      Testes Unitários.
      Mircro-Serviços
      Envio de emails
      Inclusão de meios de pagamento.
      E finalizar o modelo abaixo.

    Esse é o objetivo de modelo final para o projeto.
    Se aproxímando de uma aplicação real para locadoras de veículos:

    ![image](https://github.com/lucasmcosta0104/Locadora/assets/115005071/97bbfb53-756f-4933-913e-e723422c4116)

    

