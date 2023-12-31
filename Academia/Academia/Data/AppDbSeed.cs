using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Academia.Models;


public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        List<Comida> comidas = new() {
            new() {
                Id = 1,
                Nome = "Batata Doce",
                Descricao = "A batata-doce é considerada uma fonte de carboidrato bastante saudável, rica em fibras, proteínas, vitaminas do complexo B, vitamina A, C e diferentes sais minerais. A presença de tantas vitaminas fortalece o sistema imunológico, enquanto os sais minerais ajudam a controlar a pressão arterial. É uma fonte de carboidrato complexo de lenta absorção, fornecendo muita energia durante treinos de alta intensidade",
                Foto = "/imgs/comidas/Batata doce.jpg"
            },
            new() {
                Id = 2,
                Nome = "Frango",
                Descricao = "A carne de frango é uma ótima opção de proteína de alto valor biológico, ou seja, proteína que contém todos os aminoácidos essenciais que precisamos obter através da alimentação. É rica em vitaminas como a B12 e outras do complexo B, além de vitamina E, e minerais como selênio, potássio, ferro, zinco e outros.",
                Foto = "/imgs/comidas/Frango.jpg"
            },

        };
        builder.Entity<Comida>().HasData(comidas);



        List<Exercicio> exercicios = new() {
            new() {
                Id = 1,
                Nome = "Esteira",
                Descricao = "Temos algumas esteiras e outros aparelhos de cárdio na nossa academia,os mesmos auxiliam na perda de gordura e no fortalecimento pulmonar,fazendo com que você tenha mais fôlego e durablidade durante os outros exercícios e no seu dia dia.",
                Foto = "/imgs/exercicios/Workout1.jpg"
            },
            new() {
                Id = 2,
                Nome = "Levantamento Terra",
                Descricao = "O levantamento terra é um dos exercícios mais completos e desafiadores que existem. Ele trabalha diversos grupos musculares do corpo, como glúteos, quadríceps, isquiotibiais, lombar, dorsal, abdominal, bíceps e antebraços.",
                Foto = "/imgs/exercicios/Workout2.jpg"
            },
            new() {
                Id = 3,
                Nome = "Agachamento Livre",
                Descricao = "O agachamento é um exercício multiarticular, padrão ouro no ganho de força. Trabalha os membros e músculos inferiores de uma forma bem completa, além de fortalecer nosso core [músculos que suportam e estabilizam a bacia, pelve e abdome]",
                Foto = "/imgs/exercicios/Workout3.jpg"
            },
            new() {
                Id = 4,
                Nome = "Flexão",
                Descricao = "Ajuda a fortalecer diversos músculos. Quando feita do jeito certo, a flexão de braço ajuda a fortalecer uma série de músculos, como por exemplo:os músculos do peitoral, tríceps, ombros, abdômen, lombar e, até mesmo, dos membros inferiores.",
                Foto = "/imgs/exercicios/Workout4.jpg"
            },
            new() {
                Id = 5,
                Nome = "Corda Naval",
                Descricao = "Melhora o condicionamento físico,realizando movimentos ondulatórios e exercita toda a musculatura dos membros superiores e inferiores, além de manter uma contração constante da região do CORE (músculos da região do tronco e da coluna que suportam e estabilizam a pélvis, abdômen e bacia).",
                Foto = "/imgs/exercicios/Workout5.jpg"
            },
            new() {
                Id = 6,
                Nome = "Abdominais Bicicleta",
                Descricao = "ocam nos abdominais, nos flexores do quadril e nos oblíquos. Os músculos oblíquos se estendem pelas laterais do seu abdômen, e além de deixarem o abdômen definido, são vitais para dar suporte e estabilidade para a parte inferior das costas.",
                Foto = "/imgs/exercicios/Workout6.jpg"
            },

        };
        builder.Entity<Exercicio>().HasData(exercicios);



        List<Professor> professores = new() {
            new() {
                Id = 1,
                Nome = "Douglas",
                Descricao = "Esse é o nosso professor Douglas que vai te auxiliar no que você precisar,formado em nutrição e em educação física.",
                Foto = "/imgs/professor/douglas.jpg"
            },
            new() {
                Id = 2,
                Nome = "Lorival",
                Descricao = "Esse é o nosso professor Lorival, formado em educação física,estará dísponivel para o que voçê precisar.",
                Foto = "/imgs/professor/Val.jpg"
            },

        };
        builder.Entity<Professor>().HasData(professores);

        List<IdentityRole> roles = new()
        {
            new IdentityRole()
            {
               Id = Guid.NewGuid().ToString(),
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole()
            {
               Id = Guid.NewGuid().ToString(),
               Name = "Funcionário",
               NormalizedName = "FUNCIONARIO"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);



        List<IdentityUser> users = new(){
            new IdentityUser(){
                Id = Guid.NewGuid().ToString(),
                Email = "admin@academia.com",
                NormalizedEmail = "ADMIN@ACADEMIA.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                LockoutEnabled = false,
                EmailConfirmed = true,
            }
        };

        foreach (var user in users)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "@Etec123");
        }
        builder.Entity<IdentityUser>().HasData(users);

        List<Usuario> usuarios = new(){
            new Usuario(){
                UsuarioId = users[0].Id,
                Nome = "Douglas",
                Foto = "/imgs/batata doce.jpg"
            }
        };
        builder.Entity<Usuario>().HasData(usuarios);

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>() {
                UserId = users[0].Id,
                RoleId = roles[0].Id
            },
            new IdentityUserRole<string>() {
                UserId = users[0].Id,
                RoleId = roles[1].Id
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion

    }
}