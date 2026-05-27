import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";
import { getAuctionById } from "../../services/auctionService";
import {
  getBidsByAuctionId,
  getHighestBid,
  addBid,
} from "../../services/bidService";
import type { Auction } from "../../types/Auction";
import type { Bid } from "../../types/Bid";
import styles from "./AuctionDetailPage.module.css";

const AuctionDetailPage = () => {
  const { id } = useParams();
  const { user, isLoggedIn } = useAuth();

  const [auction, setAuction] = useState<Auction | null>(null);
  const [bids, setBids] = useState<Bid[]>([]);
  const [highestBid, setHighestBid] = useState<Bid | null>(null);
  const [bidAmount, setBidAmount] = useState<number>(0);
  const [error, setError] = useState("");
  const [success, setSuccess] = useState("");

  useEffect(() => {
    const auctionId = Number(id);

    getAuctionById(auctionId)
      .then((data) => setAuction(data))
      .catch((err) => console.error(err));

    getBidsByAuctionId(auctionId)
      .then((data) => {
        console.log("Bud:", data[0]);
        setBids(data);
      })
      .catch((err) => console.error(err));

    getHighestBid(auctionId)
      .then((data) => {
        setHighestBid(data);
        setBidAmount(data ? data.amount + 1 : 0);
      })
      .catch(() => setHighestBid(null));
  }, [id]);

  const handleBid = async () => {
    setError("");
    setSuccess("");

    if (!user) return;

    try {
      await addBid(Number(id), user.id, bidAmount);
      setSuccess("Budet lades!");

      // Uppdatera bud och högsta bud
      const updatedBids = await getBidsByAuctionId(Number(id));
      const updatedHighest = await getHighestBid(Number(id));
      setBids(updatedBids);
      setHighestBid(updatedHighest);
      setBidAmount(updatedHighest.amount + 1);
    } catch (_) {
      setError("Budet är för lågt eller ogiltigt!");
    }
  };

  if (!auction) return <p>Laddar...</p>;

  return (
    <div className={styles.container}>
      {/* VÄNSTER SIDA */}
      <div className={styles.left}>
        {auction.imageUrl && (
          <img
            src={auction.imageUrl}
            alt={auction.title}
            className={styles.mainImage}
          />
        )}
        <h1>{auction.title}</h1>
        <p className={styles.description}>{auction.description}</p>
        <p>Skapad av: {auction.createdBy}</p>
      </div>

      {/* HÖGER SIDA */}
      <div className={styles.right}>
        {/* Info-box */}
        <div className={styles.infoBox}>
          <div>
            <p>Högsta bud:</p>
            <h2>
              {highestBid
                ? `${highestBid.amount} kr`
                : `${auction.price} kr (startpris)`}
            </h2>
          </div>
          <div>
            <p>Slutar:</p>
            <h2>{new Date(auction.endDate).toLocaleDateString("sv-SE")}</h2>
          </div>
        </div>

        {/* Lägg bud */}
        {isLoggedIn && auction.isOpen && (
          <div className={styles.bidBox}>
            {error && <p className={styles.error}>{error}</p>}
            {success && <p className={styles.success}>{success}</p>}

            <input
              type="number"
              value={bidAmount}
              onChange={(e) => setBidAmount(Number(e.target.value))}
              className={styles.bidInput}
            />
            <button onClick={handleBid} className={styles.bidButton}>
              Lägg bud
            </button>
          </div>
        )}

        {!isLoggedIn && (
          <p>
            Du måste <a href="/login">logga in</a> för att buda
          </p>
        )}

        {/* Budhistorik */}
        <div className={styles.history}>
          <h3>Budhistorik</h3>
          {bids.length === 0 ? (
            <p>Inga bud ännu</p>
          ) : (
            <table className={styles.table}>
              <thead>
                <tr>
                  <th>Användare</th>
                  <th>Datum</th>
                  <th>Belopp</th>
                </tr>
              </thead>
              <tbody>
                {bids.map((bid) => (
                  <tr key={bid.id}>
                    <td>Användare {bid.userId}</td>
                    <td>{new Date(bid.bidTime).toLocaleDateString("sv-SE")}</td>
                    <td>{bid.amount} kr</td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </div>
      </div>
    </div>
  );
};

export default AuctionDetailPage;
