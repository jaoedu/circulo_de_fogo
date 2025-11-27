

# Círculo de Fogo

Jogo de luta 2.D inspirado em cultura brasileira, com arenas temáticas, sistema de “Ritual” (especial) e HUD minimalista. Feito em **Unity 6 (6000.x)**.

> Atualize aqui a versão exata da Unity (ex.: 6000.0.18f1) e o link do repositório quando subir.

## 🎮 Demo rápida
Coloque aqui um GIF curto (5–10s) ou link de vídeo do gameplay.

## ✨ Principais recursos
- Combate 1v1 em 2D (rounds, KO, tempo)
- Barra de **Ritual** (especial) com feedback visual
- Arenas temáticas (praia, centro urbano, ADEFAL, etc.)
- Suporte a **teclado** e **gamepad**
- Modo **Treino** e **Arcade** (WIP)

## 🧱 Estrutura do projeto
```
Assets/
  _Project/
    Scripts/
      Combat/           # Lógica de golpes, hitboxes/hurtboxes, estados
      Characters/       # Controladores de personagem, inputs, animações
      UI/               # HUD, menus, pausa, vitória/derrota
    Art/
    Audio/
    Prefabs/
    Scenes/
      00_Boot.unity
      01_Menu.unity
      10_Arena_Praia.unity
Packages/
ProjectSettings/
```

## 🛠️ Stack
- **Engine:** Unity 6 (6000.x)
- **Rendering:** URP (se estiver usando)
- **Input:** Input System
- **Versionamento:** Git + Git LFS (para assets grandes, opcional)

## 🚀 Como rodar
1. **Instale** a mesma versão da Unity (ex.: 6000.0.18f1).
2. **Clone** o repositório:
   ```bash
   git clone https://github.com/<seu-usuario>/<repo>.git
   cd <repo>
   ```
3. **Abra** a pasta do projeto pela Unity Hub (detecção automática).
4. Carregue a cena `01_Menu.unity` ou `10_Arena_*` e aperte **Play**.

> Dica Unity (evitar conflitos):  
> *Edit → Project Settings → Editor*  
> **Version Control:** Visible Meta Files  
> **Asset Serialization:** Force Text

## 🎯 Controles (padrão)
**Teclado player 1**
- Movimento: `A / D `
- Pular: `W`
- Golpe`Barra de espaço`

**Teclado player 2**
- Movimento: ` J / L`
- Pular: `I`
- Golpe`Barra de espaço`



