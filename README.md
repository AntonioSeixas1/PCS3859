# PCS3859
Repositório para desenvolvimento de um aplicativo em unity para a disciplina PCS3859 - Tecnologias para aplicações interativas.

O jogo coloca o paciente (jogador) em um cenário em que ele deve dissolver os inimigos chegando próximo a eles e abanando as mãos. O objetivo principal é dissolver os fantasmas que aparecem de maneira aleatória ao redor da sala, em lugares pré determinados.

**Movimentação do Jogador**
O jogador pode se movimentar pelo cenário andando normalmente. O jogo conta com a Realidade Aumentada (RA), baseada nos limites do ambiente do paciente. É necessário utilizar a RA para que o paciente seja capaz de observar os seus arredores, inserindo obstáculos a sua “vida real”.

**Ataque e Interação**
O ataque ao fantasma é feito com o jogador abanando as mãos próximo a localização do fantasma. Cada ataque reduz a "vida" do fantasma e quando atinge zero, o fantasma entra em estado de dissolução. Os fantasmas têm três vidas no total. 

**Sistema de Dissolução**
Durante o processo de dissolução, os fantasmas gradualmente desaparecem do ambiente e quando completamente dissolvidos, o jogador ganha 1 ponto no placar global.

**Respawn Aleatório**
Após ser eliminado, o fantasma será reposicionado no mapa em locais pré-definidos, exibidos na imagem como blocos. 

**Das limitações**

Devido à dificuldade de conectar o óculos Meta Quest aos computadores do grupo, foram realizadas adaptações no jogo para viabilizar a apresentação. Para simplificar, foi utilizada a funcionalidade de Play do Unity diretamente no editor. Durante a demonstração, a câmera foi movimentada manualmente, permitindo a aproximação dos fantasmas. O ataque foi realizado pressionando a tecla S, enquanto a tecla Barra de Espaço foi usada para ativar o respawn dos fantasmas.

