import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";
import { createAuction } from "../../services/auctionService";
import type { CreateAuction } from "../../types/Auction";
import styles from "./CreateAuctionPage.module.css";
import "./CreateAuctionPage.module.css";

const CreateAuctionPage = () => {
  const { user } = useAuth();
  const navigate = useNavigate();

  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [price, setPrice] = useState(0);
  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");
  const [error, setError] = useState("");

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError("");

    try {
      const newAuction: CreateAuction = {
        userId: user!.id,
        title,
        description,
        price,
        startDate,
        endDate,
      };

      await createAuction(newAuction);
      navigate("/auctions");
    } catch (_) {
      setError("Något gick fel!");
    }
  };

  return (
    <div className={styles.container}>
      <form className={styles.form} onSubmit={handleSubmit}>
        <h2>Skapa Auktion</h2>

        {error && <p className={styles.error}>{error}</p>}

        <div className={styles.inputGroup}>
          <label>Titel</label>
          <input
            type="text"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            required
          />
        </div>

        <div className={styles.inputGroup}>
          <label>Beskrivning</label>
          <textarea
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            required
          />
        </div>

        <div className={styles.inputGroup}>
          <label>Startpris (kr)</label>
          <input
            type="number"
            value={price}
            onChange={(e) => setPrice(Number(e.target.value))}
            required
          />
        </div>

        <div className={styles.inputGroup}>
          <label>Startdatum</label>
          <input
            type="datetime-local"
            value={startDate}
            onChange={(e) => setStartDate(e.target.value)}
            required
          />
        </div>

        <div className={styles.inputGroup}>
          <label>Slutdatum</label>
          <input
            type="datetime-local"
            value={endDate}
            onChange={(e) => setEndDate(e.target.value)}
            required
          />
        </div>

        <button type="submit" className={styles.button}>
          Skapa Auktion
        </button>
      </form>
    </div>
  );
};

export default CreateAuctionPage;
