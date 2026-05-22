import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";
import { login as loginService } from "../../services/authService";
import styles from "./LoginPage.module.css";
// Importer:
// useState → spara email, password, error-meddelande
// useNavigate → skicka användaren till /auctions efter login
// useAuth → hämta login-funktionen från Context
// login as loginService → döpt om för att inte krocka med login från Context

//State
const LoginPage = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");

  const { login } = useAuth();
  const navigate = useNavigate();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError("");

    try {
      const userData = await loginService(email, password);
      login(userData);
      navigate("/auctions");
    } catch (_) {
      setError("Fel e-post eller lösenord");
    }
  };

  return (
    <div className={styles.container}>
      <form className={styles.form} onSubmit={handleSubmit}>
        <h2 className={styles.title}>Logga in</h2>
        {error && <p className={styles.error}>{error}</p>}

        <div className={styles.inputGroup}>
          <label htmlFor="email">E-post</label>
          <input
            id="email"
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            placeholder="din@email.com"
            required
          />
        </div>

        <div className={styles.inputGroup}>
          <label htmlFor="password">Lösenord</label>
          <input
            id="password"
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            placeholder="*****"
            required
          />
        </div>

        <button type="submit" className={styles.button}>
          Logga in
        </button>

        <p className={styles.link}>
          Inget konto? <a href="/register">Registrera dig</a>
        </p>
      </form>
    </div>
  );
};

export default LoginPage;
