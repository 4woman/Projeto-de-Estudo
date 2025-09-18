# 📦 Sistema de Cadastro - Frota .NET

Este projeto é um sistema completo de cadastro que gerencia **endereços**, **fornecedores**, **produtos** e **usuários**, com controle de acesso por perfil (admin ou usuário). Desenvolvido com arquitetura em camadas e utilizando ferramentas modernas como **Visual Studio**, **GitHub Actions** e **Docker**.

## 🚀 Funcionalidades

- Cadastro e gerenciamento de usuários com definição de perfil (admin/usuário)
- CRUD completo para:
  - Endereços
  - Fornecedores
  - Produtos
- Interface web e console para interação
- Validações e regras de negócio encapsuladas em serviços

## 🧱 Arquitetura do Projeto

O projeto está organizado em camadas para garantir escalabilidade e manutenção:
<ul>
  <li>📁 <strong>Models</strong> – Entidades e classes de domínio</li>
  <li>📁 <strong>Services</strong> – Regras de negócio e lógica de aplicação</li>
  <li>📁 <strong>Data</strong> – Acesso a dados e persistência</li>
  <li>📁 <strong>Web</strong> – Interface web para usuários</li>
  <li>📁 <strong>ConsoleApp</strong> – Interface de linha de comando</li>
  <li>📁 <strong>UserAccess</strong> – Camada de interação com o usuário final</li>
</ul>

## 🛠️ Tecnologias Utilizadas

- **.NET / C#** com Visual Studio
- **Docker** para containerização
- **GitHub Actions** para CI/CD
- **Render** para deploy automático
- **Docker Hub** para armazenamento de imagens
- **Neon** para armazenamento do banco de dados

## ⚙️ CI/CD com GitHub Actions

A cada atualização no repositório:

1. GitHub Actions gera uma nova imagem Docker
2. A imagem é publicada automaticamente no **Docker Hub**
3. O serviço é atualizado no **Render**, garantindo deploy contínuo

## 🐳 Docker

Para executar o projeto localmente com Docker:

```bash
docker pull danivelter/zuplae-app:latest
docker run -p 8080:80 danivelter/zuplae-app:latest
```
## 🌐 Deploy
O projeto está hospedado na plataforma Render, com atualizações automáticas via GitHub Actions e Docker Hub.

👉 [Clique aqui para acessar o sistema](https://zuplae-app-latest.onrender.com)
<br/>
Login: Admin <br/>
Senha: 123

## 🌟 Apresentação do Projeto

Confira abaixo a demonstração em vídeo do funcionamento da aplicação:

<p align="center">
  <a href="https://youtu.be/M_NnxsiZdd8" target="_blank">
    <img src="https://img.youtube.com/vi/M_NnxsiZdd8/0.jpg" alt="Demonstração do projeto" width="600">
  </a>
</p>

🔗 [Clique aqui para assistir diretamente no YouTube](https://youtu.be/M_NnxsiZdd8)


## 👩‍💻 Contribuição
Sinta-se à vontade para abrir issues ou enviar pull requests. Toda contribuição é bem-vinda!

