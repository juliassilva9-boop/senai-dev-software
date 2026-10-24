import { useAuth } from './AuthContext'

function Sidebar() {
  const { user, logout } = useAuth()

  return (
    <aside>
      {/* Mantenha seus NavLinks aqui */}

      <div
        style={{
          padding: '20px',
          color: 'white',
          fontSize: '13px',
        }}
      >
        <p>👤 {user?.nome}</p>

        <button onClick={logout}>
          🚪 Sair
        </button>
      </div>
    </aside>
  )
}

export default Sidebar