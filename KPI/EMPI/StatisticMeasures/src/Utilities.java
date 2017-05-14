import org.jetbrains.annotations.Contract;

/**
 * Created by Димон on 29.03.2017.
 */
public class Utilities {

    public static void showCorelTable(int[][] array, int line, int column){
        System.out.print("y\\x||");
        for (int i = 0; i < column - 1; i++) {
            System.out.format("%4d ", (i + 1));
        }
        System.out.println(" | ny ");

        //Print underline
        for (int i = 0; i < 6 * column + 2; i++) {
            System.out.print("-");
        }
        System.out.println();
        for (int j = 0; j < line - 1; j++) {
            System.out.format("%3d||", j + 1);
            for (int i = 0; i < column - 1; i++) {

                System.out.format("%4d ",array[j][i]);
            }
            System.out.format(" |%4d%n",  array[j][column - 1]);
        }
        //Print underline
        for (int i = 0; i < 6 * column + 2; i++) {
            System.out.print("-");
        }
        System.out.println();
        System.out.print(" nx||");
        for (int i = 0; i < column - 1; i++) {
            System.out.format("%4d ",array[line - 1][i]);
        }
        System.out.format(" |%4d%n%n",  array[line - 1][column - 1]);
    }

}
