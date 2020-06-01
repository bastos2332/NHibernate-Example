# NHibernate-Example
Este projeto é um console application que faz uma pequena demonstração do uso do NHibernate.
Para utilizá-lo você procisará realizar a instalação dos seguintes pacocotes nuget:
* MySQL: `Install-Package MySql.Data -Version 8.0.20`.
* NHIBERNATE: `Install-Package NHibernate -Version 5.2.7`.

1. Adicione o arquivo **hibernate.cfg.xml**, substituindo sos dados da connection string pelas informações do seu banco de dados:
```xml
<hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
  <session-factory>
    <property name="connection.driver_class">NHibernate.Driver.MySqlDataDriver</property>
    <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
    <property name="dialect">NHibernate.Dialect.MySQL5Dialect</property>
    <property name="connection.connection_string">Server=localhost;Database=Loja;Uid=root;Pwd=@#!1q2w3e@#!</property>
    <property name="show_sql">true</property>
  </session-factory>
</hibernate-configuration>
```
2. Alterar a propriedade do arquivo para que o mesmo sempre seja copiado no output:
![Imagem janela de propiredades do arquivo XLM](https://github.com/bastos2332/NHibernate-Example/blob/master/copy.png)

3. Criar a classe de Helper do Hibernate:
```csharp
class NHibernateHelper
    {
        public static Configuration RecuperarConfiguracao ()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            return cfg;
        }

        public static void GeraSchemma()
        {
            Configuration cfg = RecuperarConfiguracao();
            new SchemaExport(cfg).Create(true, true);
        }
    }
```

5. Exemplo de classe a ser gerada:
```csharp
public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
    }
```

6. XML de configuração do mapeamento da clase acima:
```xml
<hibernate-mapping xmlns="urn:nhibernate-mapping-2.2"
  assembly="Loja"
  namespace="Loja.Entidades">
  <class name="Usuario">
    <id name="Id">
      <generator class="identity" />
    </id>
    <property name="Nome" />
  </class>
</hibernate-mapping>
```
7. Configurar o aquivo de configuração de mapeamento para que o mesmo seja um recurso inserido em tempo de comppilação:
![Imagem janela de propiredades do arquivo XLM](https://github.com/bastos2332/NHibernate-Example/blob/master/enbebed.png)

7. Código para gerar o Schemma de banco de dados.
```csharp
public class Usuario
  static void Main(string[] args)
        {
            NHibernateHelper.GeraSchemma();
            Console.Read();
        }
```



