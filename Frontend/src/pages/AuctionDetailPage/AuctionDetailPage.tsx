import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";
import { getAuctionById } from "../../services/auctionService";
import {
  getBidsByAuctionId,
  getHighestBid,
  addBid,
  deleteBid,
} from "../../services/bidService";
import type { Auction } from "../../types/Auction";
import type { Bid } from "../../types/Bid";
import styles from "./AuctionDetailPage.module.css";

const getBidIncrement = (currentPrice: number): number => {
  if (currentPrice < 500) return 50;
  if (currentPrice < 1000) return 100;
  if (currentPrice < 5000) return 250;
  if (currentPrice < 10000) return 500;
  return 750;
};

const AuctionDetailPage = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const { user, isLoggedIn, isAdmin } = useAuth();

  const [auction, setAuction] = useState<Auction | null>(null);
  const [bids, setBids] = useState<Bid[]>([]);
  const [highestBid, setHighestBid] = useState<Bid | null>(null);
  const [bidAmount, setBidAmount] = useState<number>(0);
  const [error, setError] = useState("");
  const [success, setSuccess] = useState("");

  useEffect(() => {
    const auctionId = Number(id);
    getAuctionById(auctionId).then(setAuction).catch(console.error);
    getBidsByAuctionId(auctionId).then(setBids).catch(console.error);
    getHighestBid(auctionId)
      .then((data) => {
        setHighestBid(data);
        const increment = getBidIncrement(data ? data.amount : 0);
        setBidAmount(data ? data.amount + increment : 0);
      })
      .catch(() => setHighestBid(null));
  }, [id]);

  const handleBid = async () => {
    setError("");
    setSuccess("");
    if (!user) return;

    const minBid = highestBid
      ? highestBid.amount + getBidIncrement(highestBid.amount)
      : auction!.price + getBidIncrement(auction!.price);

    if (bidAmount < minBid) {
      setError(`Budet måste vara minst ${minBid} kr!`);
      return;
    }

    try {
      await addBid(Number(id), user.id, bidAmount);
      setSuccess("Budet lades!");
      const updatedBids = await getBidsByAuctionId(Number(id));
      const updatedHighest = await getHighestBid(Number(id));
      setBids(updatedBids);
      setHighestBid(updatedHighest);
      const increment = getBidIncrement(updatedHighest.amount);
      setBidAmount(updatedHighest.amount + increment);
    } catch (_) {
      setError("Budet är för lågt eller ogiltigt!");
    }
  };

  const handleDeleteBid = async (bidId: number) => {
    try {
      await deleteBid(bidId);
      const updatedBids = await getBidsByAuctionId(Number(id));
      const updatedHighest = await getHighestBid(Number(id)).catch(() => null);
      setBids(updatedBids);
      setHighestBid(updatedHighest);
      if (updatedHighest) {
        const increment = getBidIncrement(updatedHighest.amount);
        setBidAmount(updatedHighest.amount + increment);
      } else {
        setBidAmount(auction?.price ?? 0);
      }
    } catch {
      setError("Kunde inte ta bort budet!");
    }
  };

  if (!auction) return <p>Laddar...</p>;

  const isOwner = user?.id === auction.userId;

  return (
    <div className={styles.container}>
      {/* VÄNSTER SIDA */}
      <div className={styles.left}>
        {auction.imageUrl && (
          <img
            src={auction.imageUrl}
            alt={auction.title}
            className={styles.image}
          />
        )}
        <h1>{auction.title}</h1>
        <p className={styles.description}>{auction.description}</p>
        <p>Skapad av: {auction.createdBy}</p>
        {isOwner && (
          <button
            className={styles.editBtn}
            onClick={() => navigate(`/auctions/${id}/edit`)}
          >
            Redigera auktion
          </button>
        )}
      </div>

      {/* HÖGER SIDA */}
      <div className={styles.right}>
        {/* Info box */}
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

        {/* Lägg bud - bara om öppen, inloggad, inte ägare, inte admin */}
        {isLoggedIn && auction.isOpen && !isOwner && !isAdmin && (
          <div className={styles.bidBox}>
            {error && <p className={styles.error}>{error}</p>}
            {success && <p className={styles.success}>{success}</p>}
            <input
              type="number"
              value={bidAmount}
              onChange={(e) => setBidAmount(Number(e.target.value))}
              className={styles.bidInput}
            />
            <p className={styles.minBid}>
              Minsta bud:{" "}
              {highestBid
                ? highestBid.amount + getBidIncrement(highestBid.amount)
                : auction.price + getBidIncrement(auction.price)}{" "}
              kr
            </p>
            <button onClick={handleBid} className={styles.bidButton}>
              Lägg bud
            </button>
          </div>
        )}

        {/* Meddelanden */}
        {isOwner && auction.isOpen && (
          <p className={styles.ownerMsg}>
            Du kan inte buda på din egen auktion
          </p>
        )}
        {!isLoggedIn && (
          <p>
            Du måste <a href="/login">logga in</a> för att buda
          </p>
        )}

        {/* Vinnande bud - bara om STÄNGD */}
        {!auction.isOpen && (
          <p className={styles.winnerMsg}>
            🏆 Vinnande bud:{" "}
            {highestBid ? `${highestBid.amount} kr` : "Inga bud lades"}
          </p>
        )}

        {/* Budhistorik - bara om ÖPPEN */}
        {auction.isOpen && (
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
                    <th></th>
                  </tr>
                </thead>
                <tbody>
                  {bids.map((bid, index) => (
                    <tr key={bid.id}>
                      <td>Användare {bid.userId}</td>
                      <td>
                        {new Date(bid.bidTime).toLocaleDateString("sv-SE")}
                      </td>
                      <td>{bid.amount} kr</td>
                      <td>
                        {user?.id === bid.userId &&
                          index === 0 &&
                          auction.isOpen && (
                            <button
                              className={styles.deleteBtn}
                              onClick={() => handleDeleteBid(bid.id)}
                            >
                              Ångra
                            </button>
                          )}
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            )}
          </div>
        )}
      </div>
    </div>
  );
};

export default AuctionDetailPage;
