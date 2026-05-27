import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";
import { register as registerService } from "../../services/authService";
import styles from "./RegisterPage.module.css";

const RegisterPage = () => {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");

  const { login } = useAuth();
  const navigate = useNavigate();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError("");

    try {
      const userData = await registerService(name, email, password);
      login(userData);
      navigate("/auctions");
    } catch (_) {
      setError("Något gick fel – försök igen");
    }
  };

  return (
    <div className={styles.container}>
      <form className={styles.form} onSubmit={handleSubmit}>
        <h2 className={styles.title}>Registrera dig</h2>

        {error && <p className={styles.error}>{error}</p>}

        <div className={styles.inputGroup}>
          <label htmlFor="name">Namn</label>
          <input
            id="name"
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
            placeholder="Ditt namn"
            required
          />
        </div>

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
            placeholder="********"
            required
          />
        </div>

        <button type="submit" className={styles.button}>
          Registrera
        </button>

        <p className={styles.link}>
          Har du redan konto? <a href="/login">Logga in</a>
        </p>
      </form>
    </div>
  );
};

export default RegisterPage;
