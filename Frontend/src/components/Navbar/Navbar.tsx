import { Link } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";
import styles from "./Navbar.module.css";

const Navbar = () => {
  const { isLoggedIn, isAdmin, logout } = useAuth(); //Hämta 3 saker från AuthContext

  return (
    // <nav> = HTML-element speciellt för navigation
    <nav className={styles.navbar}>
      {/* 👉 Loggan längst till vänster
        Klickar man på den → går man till /auctions   */}
      <Link to="/auctions" className={styles.logo}>
        AuctionApp
      </Link>

      <div className={styles.links}>
        {/* 
            👉 Dessa länkarna visas alltid – för alla användare
                Även om man inte är inloggad */}

        <Link to="/auctions">Auktioner</Link>
        <Link to="/closed">Avslutade</Link>

        {isLoggedIn ? (
          <>
            <Link to="/create">Skapa auktion</Link>
            {isAdmin && <Link to="/admin">Admin</Link>}
            <Link to="/profile">Profil</Link>
            <button onClick={logout}>Logga ut</button>
          </>
        ) : (
          <>
            <Link to="/login">Logga in</Link>
            {/* <Link to="/register">Register</Link> */}
          </>
        )}
      </div>
    </nav>
  );
};

export default Navbar;
