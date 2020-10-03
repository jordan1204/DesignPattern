using System;

class GFG {
	public interface IState {
		bool addToCart (int userId);
	}
	public class OpenState : IState {
		Ticket context;
		public OpenState (Ticket ticket) {
			this.context = ticket;
		}
		public bool addToCart (int userId) {
			this.context.userId = userId;
			this.context.setState(new InCartState(this.context));
    		return true;
		}
	}

	public class InCartState:IState {
  		public Ticket context;

  		public InCartState(Ticket ticket) {
    		this.context = ticket;
  		}

  // Logic of addToCart() when the state is InCartState.
  public bool addToCart(int userId){
    if (this.context.userId == userId) {
      Console.WriteLine("You have already added this ticket to your cart.");
      return true;
    } else {
      Console.WriteLine("This ticket has been added by someone.");
      return false;
    }
  }
}
	public class Ticket {
		public int seatId;
		public int userId;
		public IState state;//reference to state
		public Ticket (int seatId) {
			this.seatId = seatId;
			this.state = new OpenState (this);
		}

		public void printTicket () {
			Console.WriteLine (string.Format("This ticket's seat id is {0}",this.seatId));
		}
		public void setState (IState state) {
			this.state = state;
		}
		public bool addToCart(int userId) {
    		return this.state.addToCart(userId);
  		}
	}
	// Main Method 
	static public void Main () {
		Ticket ticket = new Ticket (1);
		int user0 = 0;
		int user1 = 1;
		ticket.printTicket ();
		Console.WriteLine ("It should be able to be added by user 0. ");
		Console.WriteLine (ticket.addToCart (user0));
		Console.WriteLine ("It should be return true and print the information.");
		Console.WriteLine (ticket.addToCart (user0)); // Return: true

		Console.WriteLine ("It should not be able to be added to cart by user 1. ");
		// Output: This ticket has been added by someone.
		Console.WriteLine (ticket.addToCart (user1)); // 
	}
}