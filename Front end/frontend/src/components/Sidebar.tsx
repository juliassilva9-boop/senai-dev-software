<aside className="sidebar">

  {/* LOGO */}
  <div className="sidebar-logo">
    <div className="logo-symbol">◆</div>

    <div className="logo-content">
      <strong>Nova</strong>
      <span>System</span>
    </div>
  </div>

  {/* MENU */}
  <nav className="sidebar-menu">

    <span className="menu-title">MENU PRINCIPAL</span>

    <a href="/" className="sidebar-link active">
      <span className="sidebar-icon">⌂</span>
      <span>Dashboard</span>
    </a>

    <a href="/clientes" className="sidebar-link">
      <span className="sidebar-icon">♙</span>
      <span>Clientes</span>
    </a>

    <a href="/produtos" className="sidebar-link">
      <span className="sidebar-icon">▣</span>
      <span>Produtos</span>
    </a>

    <a href="/relatorios" className="sidebar-link">
      <span className="sidebar-icon">◫</span>
      <span>Relatórios</span>
    </a>

    <span className="menu-title menu-system">
      SISTEMA
    </span>

    <a href="/configuracoes" className="sidebar-link">
      <span className="sidebar-icon">⚙</span>
      <span>Configurações</span>
    </a>

  </nav>

  {/* USUÁRIO */}
  <div className="sidebar-user">

    <div className="user-avatar">
      JS
    </div>

    <div className="user-details">
      <strong>Usuário</strong>
      <span>Administrador</span>
    </div>

    <button className="logout-button" title="Sair">
      ⇥
    </button>

  </div>

</aside>