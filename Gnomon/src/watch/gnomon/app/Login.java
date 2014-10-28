package watch.gnomon.app;

public class Login {

	
	private String username = "Robo";
	private String password = "cop";
	
	
	
	
	public boolean checkLogin(String username, String password){
		return (this.username.equals(username) && this.password.equals(password));
	}
	
	
	
	
	
	
}
