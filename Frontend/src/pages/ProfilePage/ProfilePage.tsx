import { useState } from "react";
import { useAuth } from "../../context/AuthContext";
import { updatePassword } from "../../services/authService";
import styles from "./ProfilePage.module.css";

const ProfilePage = () => {
  const { user } = useAuth();

  const [oldPassword, setOldPassword] = useState("");
  const [newPassword, setNewPassword] = useState("");
  const [error, setError] = useState("");
  const [success, setSuccess] = useState("");

  const handlePasswordUpdate = async (e: React.FormEvent) => {
    e.preventDefault();
    setError("");
    setSuccess("");

    try {
      await updatePassword(user!.id, oldPassword, newPassword);
      setSuccess("Lösenord uppdaterat!");
      setOldPassword("");
      setNewPassword("");
    } catch (_) {
      setError("Fel lösenord eller något gick fel!");
    }
  };

  return (
    <div className={styles.container}>
      <div className={styles.card}>
        <h2>Min Profil</h2>
        <p>
          <strong>Namn:</strong> {user?.name}
        </p>
        <p>
          <strong>Email:</strong> {user?.email}
        </p>
        <p>
          <strong>Role: {user?.role}</strong>
        </p>
      </div>

      <div className={styles.card}>
        <h2>Byt Läsenord</h2>

        {error && <p className={styles.error}>{error}</p>}
        {success && <p className={styles.success}>{success}</p>}

        <form onSubmit={handlePasswordUpdate}>
          <div className={styles.inputGroup}>
            <label>Gammalt lösenord</label>
            <input
              type="password"
              value={oldPassword}
              onChange={(e) => setOldPassword(e.target.value)}
              required
            />
          </div>
          <div className={styles.inputGroup}>
            <label>Nytt lösenord</label>
            <input
              type="password"
              value={newPassword}
              onChange={(e) => setNewPassword(e.target.value)}
              required
            />
          </div>

          <button type="submit" className={styles.button}>
            Spara
          </button>
        </form>
      </div>
    </div>
  );
};

export default ProfilePage;
