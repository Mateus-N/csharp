static int[] TwoSum(int[] nums, int target)
{
    nums = [.. nums.Order()];

    int i = 0;
    int j = nums.Length - 1;

    while (i < j)
    {
        int res = nums[i] + nums[j];

        if (res == target)
        {
            return [nums[i], nums[j]];
        }

        if (res > target)
        {
            j--;
        }

        if (res < target)
        {
            i++;
        }
    }

    return [];
}


int[] res = TwoSum([1, 2, 3, 4, 5, 6], 10);
Console.WriteLine($"[{res[0]}, {res[1]}]");
