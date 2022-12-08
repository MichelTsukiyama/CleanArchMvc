# Projeto Clean Architecture

-----

## Objetivo

Construir um projeto com conceitos de arquitetura limpa, utilizando:

- Net 5.0;
- SQL;
  
----

## Estrutura do Projeto

- Domnínio; 
- Application (depende do domínio);
- Infra.Data (depende do domínio);
- Infra.IoC (depende do domínio, application e infra.data);
- WebUI (depende da infra.ioc)
  
----

## Versionamento

Versionamento feito com Git, utilizando as branchs abaixo:

- main (projeto principal, produção);
- develop (branch de desenvolvimento);
- feature/nome-da-feature (branch de desenvolvimento de nova feature);
- hotfix/nome-do-hotfix (branch para correções de bugs existentes na main/produção);

---